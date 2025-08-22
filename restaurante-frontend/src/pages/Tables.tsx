import { useEffect, useState } from "react";
import api from "../services/api";

type Table = {
  id: number;
  number: number;
  status: "aberta" | "fechada";
};

export default function Tables() {
  const [tables, setTables] = useState<Table[]>([]);

  // Buscar mesas ao carregar
  useEffect(() => {
    const fetchTables = async () => {
      try {
        const response = await api.get<Table[]>("/tables");
        setTables(response.data);
      } catch (error) {
        console.error("Erro ao carregar mesas", error);
      }
    };

    fetchTables();
  }, []);

  // Abrir mesa
  const abrirMesa = async () => {
    try {
      const response = await api.post<Table>("/tables", {
        number: tables.length + 1,
        status: "aberta",
      });
      setTables([...tables, response.data]);
    } catch (error) {
      console.error("Erro ao abrir mesa", error);
    }
  };

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Mesas</h1>

      <button
        onClick={abrirMesa}
        className="mb-6 px-4 py-2 bg-green-600 text-white rounded-lg shadow hover:bg-green-700 transition"
      >
        Abrir Nova Mesa
      </button>

      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
        {tables.map((mesa) => (
          <div
            key={mesa.id}
            className={`p-6 rounded-xl shadow-lg border-2 ${
              mesa.status === "aberta"
                ? "border-green-500 bg-green-50"
                : "border-gray-400 bg-gray-100"
            }`}
          >
            <h2 className="text-xl font-semibold">Mesa {mesa.number}</h2>
            <p
              className={`mt-2 text-sm ${
                mesa.status === "aberta" ? "text-green-700" : "text-gray-600"
              }`}
            >
              {mesa.status === "aberta" ? "Aberta" : "Fechada"}
            </p>
          </div>
        ))}
      </div>
    </div>
  );
}
