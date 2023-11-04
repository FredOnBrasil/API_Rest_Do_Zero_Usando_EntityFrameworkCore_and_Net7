namespace DevEventAPI.Entities
{
    public class Evento
    {
        public Evento(/*int id,*/string titulo, string descricao, DateTime dataInicio, DateTime dataFim, string organizador)
        {
            //Id = id; //comentado o id pois o EF será responsável por incrementar o id a partir de agora
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Organizador = organizador;

            DataCriacao = DateTime.Now;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public String Organizador { get; set; }
        public DateTime DataCriacao { get; set; }

        public void Update(string titulo, string descricao, DateTime dataInicio, DateTime dataFim)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
        }
    }
}
