import { BrowserRouter, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Tables from "./pages/Tables";

export default function App() {
  return (
    <BrowserRouter>
      <Navbar />
      <Routes>
        <Route path="/" element={<Tables />} />
        <Route path="/orders" element={<div className="p-6">Página de Pedidos</div>} />
        <Route path="/products" element={<div className="p-6">Página de Produtos</div>} />
      </Routes>
    </BrowserRouter>
  );
}
