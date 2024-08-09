import { lazy, Suspense } from 'react'
import Header from './layout/Header'
import Route from './navigation/Route'
import Router from './navigation/Router'
const Home = lazy(() => import('./pages/Home'))
const Registro = lazy(() => import('./pages/Registro'))


function App() {

  return (
    <div id="bg">
      <Header />
      <main className='mi-container py-3'>
        <div className="main-padding">
          <Suspense fallback={null}>
            <Router>
              <Route to="/" Component={Home} title='Home' />
              <Route to="/registro" Component={Registro} title='Registro' />
            </Router>
          </Suspense>
        </div>
      </main>
    </div>
  )
}

export default App
