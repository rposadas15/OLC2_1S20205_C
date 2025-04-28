public class SimbolosDTO {

    public string identificador;
    public string tipo;
    public Object? valor;

    public Dictionary<string, Object>? valorStruct;

    public string valorXArm64;

    public SimbolosDTO(string identificador, string tipo, Object valor, valorXArm64) {
        this.identificador = identificador;
        this.tipo = tipo;
        this.valor = valor;
        this.valorXArm64 = valorXArm64;
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