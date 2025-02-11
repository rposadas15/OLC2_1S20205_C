public class ErroresDTO {
    public string tipoError { get; set; }
    public string descripcion { get; set; }
    public int linea { get; set; }
    public int columna { get; set; }

    public ErroresDTO(string tipoError, string descripcion, int linea, int columna) {
        this.tipoError = tipoError;
        this.descripcion = descripcion;
        this.linea = linea;
        this.columna = columna;
    }
}