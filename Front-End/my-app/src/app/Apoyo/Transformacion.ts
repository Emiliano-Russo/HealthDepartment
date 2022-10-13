export function FormateadorMinutosEnHoras(cantMinutos: number): string {
  if (cantMinutos > 60) {
    var num = cantMinutos;
    var hours = num / 60;
    var rhours = Math.floor(hours);
    var minutes = (hours - rhours) * 60;
    var rminutes = Math.round(minutes);
    return rhours + 'h:' + rminutes + 'm';
  }

  return cantMinutos + 'm';
}
