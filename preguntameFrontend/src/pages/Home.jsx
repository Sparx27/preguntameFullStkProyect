
import './Home.css'

export default function Home() {

  return (
    <div id='home-container' className="container-fluid">
      <div className="row d-flex justify-content-center w-100">
        <h1 className="col-12 text-center oscuro">Preguntá a quien quieras. Incluso de forma anónima!</h1>
        <form id="home-form" className="col-8 col-lg-6 d-flex mt-4">
          <input type="text" className="w-100" placeholder='Buscar username' />
          <input type="submit" value="BUSCAR" />
        </form>
      </div>
    </div>
  )
}