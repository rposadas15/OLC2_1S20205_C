public class FuncionDTO {

    public string identificador;
    public Dictionary<string, SimbolosDTO> parametros { get; set; }
    public AnalizadorLexicoParser.ListainstruccionesContext instrucciones { get; set; }
    public List<String> tipoParametros { get; set; }
    public SimbolosDTO retorno { get; set; }
    public EntornoDTO? entorno { get; set; }

    public FuncionDTO(string identificador, Dictionary<string, SimbolosDTO> parametros, AnalizadorLexicoParser.ListainstruccionesContext instrucciones, List<String> tipoParametros, SimbolosDTO retorno) {
        this.identificador = identificador;
        this.parametros = parametros;
        this.instrucciones = instrucciones;
        this.tipoParametros = tipoParametros;
        this.retorno = retorno;
    }

}