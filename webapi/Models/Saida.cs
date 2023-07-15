﻿namespace webapi.Models
{
    public class Saida
    {
        private int Id { get; set; }
        private int Quantidade { get; set; }
        private DateTime DataHora { get; set; }
        private string Local { get; set; }
        private List<Mercadoria> Mercadorias { get; set; }
    }
}