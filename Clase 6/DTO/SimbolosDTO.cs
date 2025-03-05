public class SimbolosDTO {

    public string identificador;
    public string tipo;
    public Object? valor;

    public Dictionary<string, Object>? valorStruct;

    public SimbolosDTO(string identificador, string tipo, Object valor) {
        this.identificador = identificador;
        this.tipo = tipo;
        this.valor = valor;
    }

    public SimbolosDTO(string identificador, string tipo, Dictionary<string, Object> valorStruct) {
        this.identificador = identificador;
        this.tipo = tipo;
        this.valorStruct = valorStruct;
    }

    public SimbolosDTO(string identificador, string tipo) {
        this.identificador = identificador;
        this.tipo = tipo;
    }

}