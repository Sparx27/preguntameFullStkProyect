import './Header.css'
import logo from '../assets/logo.webp'
import Link from '../navigation/Link'


export default function Header() {

  return (
    <div id='header-container' className='container-fluid bg-blanco shadow-sm'>
      <div className="mi-container">
        <nav className='d-flex justify-content-between align-items-center py-2' id='header'>

          <img src={logo} alt="preguntame" className='img-fluid my-1' width="250px" />

          <div className='d-flex align-items-center'>
            <form className="d-none me-2" role="search">
              <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search" />
              <button className="btn btn-outline-success" type="submit">Search</button>
            </form>
            <div className="ms-4">
              <div className='d-flex m-0 p-0 gap-4'>
                <Link to="/" className='a-oscuro a-animado text-center mx-2' active="true">Buscar usuario</Link>
                <a className='a-oscuro a-animado text-center mx-2' href="#">Ingresar</a>
                <Link to="/registro" className='a-oscuro a-animado text-center mx-2'>Registro</Link>
              </div>
            </div>
          </div>

        </nav>
      </div>
    </div>
  )

}