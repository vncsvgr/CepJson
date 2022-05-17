using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace ProjetoCepJson
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnPesquisa_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string cep = edtCEP.Text;
            var json = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
            var dados = JsonConvert.DeserializeObject<CEP>(json);

            edtLogradouro.Text = dados.logradouro;
            edtComplemento.Text = dados.complemento;
            edtBairro.Text = dados.bairro;
            edtLocalidade.Text = dados.localidade;
            edtUF.Text = dados.uf;

        }
    }
}
