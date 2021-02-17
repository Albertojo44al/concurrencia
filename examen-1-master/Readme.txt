1. Todos los threads estan trabajando sobre la misma variable sin ningun orden especifico
 y crea un conflicto, ya que pueden sobrescribir la variable.
 
2. Aplicar un mutex a la hora de llamar dentro de la funcion count que permita que solo un thread
 pueda modificar la funcion global a la vez agregaria un mutex lock en la linea 31 y un unlock
 en la linea 33.
   