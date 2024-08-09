import './Registro.css'
import registroimg from '../assets/registro_img.webp'

export default function Registro() {


  return (
    <div id="registro-container" className="container-fluid">
      <div className="row rounded-4 overflow-hidden shadow-lg">
        <div className="col-6 px-0 bg-blanco">
          <div className='px-5 pt-4'>
            <h1 className='text-center oscuro mb-4'>Registro</h1>
            <form>
              <input type="text" className='input-pill mb-3 mt-1' placeholder='username' />
              <input type="mail" className='input-pill mb-3 mt-1' placeholder='email' />
              <input type="password" className='input-pill mb-3 mt-1' placeholder='password' />
              <input type="submit" value="Registrarme!" className='btn-pill w-100 fs-3' />
            </form>
          </div>
        </div>
        <figure className="col-6 px-0"><img src={registroimg} alt="gente preguntando" className='w-100' /></figure>
      </div>
    </div>
  )
}