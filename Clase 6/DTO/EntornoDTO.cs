public class EntornoDTO {

    public string nombre { get; set; }
    public Dictionary<string, SimbolosDTO> variables { get; set; }
    public EntornoDTO? punteroAPadre { get; set; }
    public EntornoDTO? punteroASiguiente { get; set; }
    public int ultimaPosicion { get; set; }

    public EntornoDTO(string nombre, EntornoDTO? entorno) {
        this.nombre = nombre;
        this.variables = new Dictionary<string, SimbolosDTO>();
        this.punteroAPadre = entorno;
        this.ultimaPosicion = 0;
    }

    public SimbolosDTO? buscarVariable(string nombre) {
        for (EntornoDTO? ent = this; ent != null; ent = ent.punteroAPadre) {
            if (ent.variables.ContainsKey(nombre)) {
                Console.WriteLine("La estoy encontrando en padre");
                return ent.variables[nombre];                
            }
        }
        for (EntornoDTO? ent = this; ent != null; ent = ent.punteroASiguiente) {
            if (ent.variables.ContainsKey(nombre)) {
                Console.WriteLine("La estoy encontrando en siguiente");
                return ent.variables[nombre];                
            }
        }
        return null;
    }

    public void guardarVariable(string nombre, SimbolosDTO simbolo) {
        if (variables.ContainsKey(nombre)) 
            Console.Write("Variable " + nombre + " ya existe");
        else 
            variables.Add(nombre, simbolo);
    }

    public void actualizarValorSimbolo(string nombre, object valor) {
        for (EntornoDTO? ent = this; ent != null; ent = ent.punteroAPadre) {
            if (ent.variables.ContainsKey(nombre)) {
                SimbolosDTO simbolo = ent.variables[nombre];
                simbolo.valor = valor;
                ent.variables[nombre] = simbolo;
                Console.WriteLine("Variable " + nombre + " se actualizó al valor: " + valor);
            }
        }
    }

}