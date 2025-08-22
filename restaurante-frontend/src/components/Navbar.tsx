import { Link } from "react-router-dom";

export default function Navbar() {
  return (
    <nav className="bg-gray-900 text-white p-4 flex gap-6">
      <Link to="/" className="hover:text-gray-300">Mesas</Link>
      <Link to="/orders" className="hover:text-gray-300">Pedidos</Link>
      <Link to="/products" className="hover:text-gray-300">Produtos</Link>
    </nav>
  );
}
