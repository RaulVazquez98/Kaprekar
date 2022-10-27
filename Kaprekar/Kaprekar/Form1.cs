using System.Collections.Immutable;

namespace Kaprekar
{
    public partial class result_area : Form
    {
        List<ValoresImp> lista = new List<ValoresImp>();
        List<int> list = new List<int>();
        int resultado = 0;
        int contador = 0;
        string ascendente = "";
        string descendiente = "";
        string Valor_inicial = null;
        public result_area()
        {
            InitializeComponent();
            
        }
        public class ValoresImp
        {
            public int resultados { get; set; }
            public int vuelta { get; set; }
        }
        private void btn_generate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(InitValue.Text))
            {
                MessageBox.Show("No hay datos", "Error");
                return;
            }
            Valor_inicial = InitValue.Text;
            funcOrder(Valor_inicial);

            while (resultado != 6174)
            {
                resultado = Convert.ToInt32(ascendente) - Convert.ToInt32(descendiente);
                contador += 1;
                lista.Add(new ValoresImp { resultados = resultado, vuelta = contador });
                funcOrder(Convert.ToString(resultado));
            }

            for(int i =0; i<lista.Count; i++)
            {
                Result.AppendText(lista[i].resultados.ToString() + "\t");
                Result.AppendText(lista[i].vuelta.ToString() + "\n");
            }

            
        }
        public void funcOrder(string x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                list.Add(x[i] - '0');
            }
            list.Sort();
            descendiente = string.Join("", list);
            list.Reverse();
            ascendente = string.Join("", list);
            list.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(InitValue.Text == "")
            {
                MessageBox.Show("No hay datos", "Error");
                return;
            }
            Valor_inicial = null;
            InitValue.Text = "";
            Result.Text = "";
            
        }

        private void InitValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}