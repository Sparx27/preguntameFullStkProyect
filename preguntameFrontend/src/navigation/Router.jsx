import { useState, useEffect, Children } from "react";


export default function Router({ children, defaultComponent: DefaultComponent = () => <h1>404</h1> }) {
  const [pathActual, setPathCual] = useState(window.location.pathname)

  useEffect(() => {
    const alCambiarPagina = () => { setPathCual(window.location.pathname) }
    window.addEventListener('pushstate', alCambiarPagina)
    window.addEventListener('popstate', alCambiarPagina)

    return () => {
      window.removeEventListener('pushstate', alCambiarPagina)
      window.removeEventListener('popstate', alCambiarPagina)
    }
  }, [])

  const ListaDeRoutes = Children.map(Array(children), (hijo) => {
    if (hijo.type.name !== "Route") return null

    return {
      path: hijo.props.to,
      Component: hijo.props.Component,
      title: hijo.props.title
    }
  })

  const EncontrarPagina = ListaDeRoutes.find(route => route?.path === pathActual)
  if (EncontrarPagina) {
    document.title = EncontrarPagina.title
  }

  return EncontrarPagina ? <EncontrarPagina.Component /> : <DefaultComponent />
}