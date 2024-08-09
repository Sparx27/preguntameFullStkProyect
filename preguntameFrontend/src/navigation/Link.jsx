
function navegar(href) {
  window.history.pushState({}, '', href)
  const eventoPushState = new Event('pushstate')
  window.dispatchEvent(eventoPushState)
}

export default function Link({ to, target, ...props }) {
  function navegarHandler(e) {
    const esSelf = target == undefined || target == "_self"
    const esConTecla = e.metaKey || e.shiftKey || e.ctrlKey || e.altKey
    const esMainClick = e.button == 0

    if (esSelf && !esConTecla && esMainClick) {
      e.preventDefault()
      navegar(to)
      window.scrollTo(0, 0)
    }
  }

  return <a target={target} href={to} onClick={navegarHandler} {...props} />
}