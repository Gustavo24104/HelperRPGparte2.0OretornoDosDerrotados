using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HelperRPGparte2._0OretornoDosDerrotados.Properties;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;



namespace HelperRPGparte2._0OretornoDosDerrotados
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    /// 

    public partial class MainWindow : Window {


        public List<TextBox> textBoxesList = new List<TextBox>();
        public List<TextBox> textBoxesQntList = new List<TextBox>();
        public List<TextBox> textBoxesMagic = new List<TextBox>();
        public List<TextBox> textBoxesMagicCusto = new List<TextBox>();
        public int marginTopPlacement = 55; //Adicionando de 30 em 30.
        public int currentMoney = 0;

        SerializadorDeData saveLoad = new SerializadorDeData();

        





        public MainWindow() {
            InitializeComponent();
            this.Closed += new EventHandler(MainWindow_Closed);
            AddMagic();
            //Chama o metódo de carregar
            Loader();
            //currentMoney = Int32.Parse(saveLoad.DesirializarXML(typeof(int), "data.Save").ToString());
            //txtBlockMoney.Text = "Dinheiro: " + currentMoney;


        }

        public void AddMagic() {
            textBoxesMagic.Add(txtBoxMagia);
            textBoxesMagic.Add(txtBoxMagia_Copy);
            textBoxesMagic.Add(txtBoxMagia_Copy1);
            textBoxesMagic.Add(txtBoxMagia_Copy2);
            textBoxesMagic.Add(txtBoxMagia_Copy3);
            textBoxesMagic.Add(txtBoxMagia_Copy4);
            textBoxesMagic.Add(txtBoxMagia_Copy5);
            textBoxesMagicCusto.Add(txtCustoMagia);
            textBoxesMagicCusto.Add(txtCustoMagia_Copy);
            textBoxesMagicCusto.Add(txtCustoMagia_Copy1);
            textBoxesMagicCusto.Add(txtCustoMagia_Copy2);
            textBoxesMagicCusto.Add(txtCustoMagia_Copy3);
            textBoxesMagicCusto.Add(txtCustoMagia_Copy4);
            textBoxesMagicCusto.Add(txtCustoMagia_Copy5);
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            CreateQntBlock();
            CreateItemBlock();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e) {
            RemoveQntBlock();
            RemoveItemBlock();
        }

        void CreateQntBlock() {
            TextBox txbt = new TextBox();
            txbt.Background = new SolidColorBrush(Color.FromRgb(64, 64, 64));
            txbt.Foreground = new SolidColorBrush(Color.FromRgb(143, 143, 143));
            txbt.Width = 50;
            txbt.Height = 20;
            allGrid.Children.Add(txbt);
            txbt.HorizontalAlignment = HorizontalAlignment.Left;
            txbt.VerticalAlignment = VerticalAlignment.Top;
            txbt.Margin = new Thickness(110, marginTopPlacement, 0, 0);
            textBoxesQntList.Add(txbt);


        }

        void CreateItemBlock() {
            TextBox txbt = new TextBox();
            txbt.Background = new SolidColorBrush(Color.FromRgb(64, 64, 64));
            txbt.Foreground = new SolidColorBrush(Color.FromRgb(143, 143, 143));
            txbt.Width = 90;
            txbt.Height = 20;
            allGrid.Children.Add(txbt);
            txbt.HorizontalAlignment = HorizontalAlignment.Left;
            txbt.VerticalAlignment = VerticalAlignment.Top;
            txbt.Margin = new Thickness(10, marginTopPlacement, 0, 0);
            textBoxesList.Add(txbt);
            marginTopPlacement += 30;
        }

        void RemoveItemBlock() {
            if (textBoxesList.Count != 0) {
                allGrid.Children.Remove(textBoxesList.Last());
                textBoxesList.Remove(textBoxesList.Last());
                marginTopPlacement -= 30;
            }
        }

        void RemoveQntBlock() {
            if (textBoxesQntList.Count != 0) {
                allGrid.Children.Remove(textBoxesQntList.Last());
                textBoxesQntList.Remove(textBoxesQntList.Last());
            }


        }
        int addMoney() {
            int howMuch;
            bool success = Int32.TryParse(txtDinheiroQnt.Text, out howMuch);
            if (success) {
                return howMuch;
                //currentMoney += howMuch;
                //txtBlockMoney.Text = "Dinheiro: " + currentMoney;
            }
            else {
                MessageBox.Show("Número invalido ou resultado menor que 0!", "Meu Deus cara, tu é burro???????? aprende a contar");
                return 0;
                //
            }

        }

        int subMoney() {
            int howMuch;
            bool success = Int32.TryParse(txtDinheiroQnt.Text, out howMuch);
            if (success && currentMoney - howMuch >= 0) {
                return howMuch;
            }
            else {
                MessageBox.Show("Número invalido ou resultado menor que 0!", "Meu Deus cara, tu é burro???????? aprende a contar");
                return 0;
                //Aviso
            }
        }

        int multMoney() {
            int howMuch;
            bool success = Int32.TryParse(txtDinheiroQnt.Text, out howMuch);
            if (success && currentMoney - howMuch >= 0) {
                return howMuch;
            }
            else {
                MessageBox.Show("Número invalido ou resultado menor que 0!", "Meu Deus cara, tu é burro???????? aprende a contar");
                return 0;
            }
        }

        int divMoney() {
            int howMuch;
            bool success = Int32.TryParse(txtDinheiroQnt.Text, out howMuch);
            if (success && currentMoney - howMuch >= 0 && currentMoney != 0 && howMuch != 0) {
                return howMuch;
            }
            else {
                MessageBox.Show("Número invalido ou resultado menor que 0!", "Meu Deus cara, tu é burro???????? aprende a contar");
                return 1;
                //Aviso
            }
        }

        private void btnAddMoney_Click_1(object sender, RoutedEventArgs e) {
            currentMoney += addMoney();
            txtBlockMoney.Text = "Dinheiro: " + currentMoney;
            if (currentMoney == 69) MessageBox.Show("Nice", "Nice");
        }

        private void btnSubtractMoney_Click_1(object sender, RoutedEventArgs e) {
            currentMoney -= subMoney();
            txtBlockMoney.Text = "Dinheiro: " + currentMoney;
            if (currentMoney == 69) MessageBox.Show("Nice", "Nice");
        }

        private void btnDivMoney_Click(object sender, RoutedEventArgs e) {
            currentMoney /= divMoney();
            txtBlockMoney.Text = "Dinheiro: " + currentMoney;
            if (currentMoney == 69) MessageBox.Show("Nice", "Nice");
        }

        private void btnMultMoney_Click(object sender, RoutedEventArgs e) {
            currentMoney *= multMoney();
            txtBlockMoney.Text = "Dinheiro: " + currentMoney;
            if (currentMoney == 69) MessageBox.Show("Nice", "Nice");

        }

        void MainWindow_Closed(object sender, EventArgs e) {

            MessageBox.Show("Salvo com sucesso?", "Vo bani");
            Save();
        }


        //Função gigante em 3
        //2
        //1
        //Boa sorte, negócios pra salvar, tenho dó de quem for ver isso
        void Save() {


            //Chama o serializador pra salvar;
            saveLoad.SerializarXML(typeof(int), currentMoney, "Data/money.meme");

            saveLoad.SerializarXML(typeof(string), txtHabilidade.Text, "Data/habilidade.meme");

            saveLoad.SerializarXML(typeof(string), txtBoxItem1.Text, "Data/tb1.meme");
            saveLoad.SerializarXML(typeof(string), txtQnt1.Text, "Data/tq1.meme");
            saveLoad.SerializarXML(typeof(string), txtArma1Nome.Text, "Data/arma1n.meme");
            saveLoad.SerializarXML(typeof(string), txtArma1Descrição.Text, "Data/arma1d.meme");
            saveLoad.SerializarXML(typeof(string), txtArma2Nome.Text, "Data/arma2n.meme");
            saveLoad.SerializarXML(typeof(string), txtArma2Descrição.Text, "Data/arma2d.meme");

            //Salva o número de itens q existem.
            saveLoad.SerializarXML(typeof(int), textBoxesList.Count, "Data/itensNumero.meme");
            
            //Salva o texto das textBoxe AKA os itens
            int i = 0;
            foreach  (var txt in textBoxesList) {
                saveLoad.SerializarXML(typeof(string), txt.Text, "Data/itensTxt/" + i + "itensTxt.meme");
                i++;
            }

            i = 0;
            foreach (var qnt in textBoxesQntList) {
                saveLoad.SerializarXML(typeof(string), qnt.Text, "Data/itensQnt/" + i + "itensQnt.meme");
                i++;
            }

            i = 0;
            foreach (TextBox magics in textBoxesMagic) {
                saveLoad.SerializarXML(typeof(string), magics.Text, "Data/magic/" + i + "magicName.meme");
                i++;
            }

            i = 0;
            foreach (TextBox magicCu in textBoxesMagicCusto) {
                saveLoad.SerializarXML(typeof(string), magicCu.Text, "Data/magic/" + i + "magicCu.meme");
                i++;
            }

            


            
           
            //saveLoad.SerializarXML(typeof(int), currentMoney, "data.Save");
            

            /*
            Settings.Default.NomeArma1 = txtArma1Nome.Text;
            Settings.Default.NomeArma2 = txtArma2Nome.Text;
            Settings.Default.DescricaoArma1 = txtArma1Descrição.Text;
            Settings.Default.DescricaoArma2 = txtArma2Descrição.Text;
            Settings.Default.Dinheiro = currentMoney;
            Settings.Default.Habilidade = txtHabilidade.Text
            Settings.Default.Save();
            */
        }

        //Carregar os itens
        public void Loader() {


            currentMoney = Convert.ToInt32(saveLoad.DesirializarXML(typeof(int), "Data/money.meme"));
            txtBlockMoney.Text = "Dinheiro: " + currentMoney;
            txtBoxItem1.Text = saveLoad.DesirializarXML(typeof(string), "Data/tb1.meme").ToString();
            txtQnt1.Text = saveLoad.DesirializarXML(typeof(string), "Data/tq1.meme").ToString();
            txtHabilidade.Text = saveLoad.DesirializarXML(typeof(string), "Data/habilidade.meme").ToString();
            txtArma1Nome.Text = saveLoad.DesirializarXML(typeof(string), "Data/arma1n.meme").ToString();
            txtArma1Descrição.Text = saveLoad.DesirializarXML(typeof(string), "Data/arma1d.meme").ToString();
            txtArma2Nome.Text = saveLoad.DesirializarXML(typeof(string), "Data/arma2n.meme").ToString();
            txtArma2Descrição.Text = saveLoad.DesirializarXML(typeof(string), "Data/arma2d.meme").ToString();


            //Carrega o número de itens
            for (int i = 0; i < Convert.ToInt32(saveLoad.DesirializarXML(typeof(int), "Data/itensNumero.meme")); i++) {
                CreateQntBlock();
                CreateItemBlock();
            }

            int j = 0;
            //Carrega o texto em cada item
            foreach (TextBox txt in textBoxesList) {
            //    if(saveLoad.DesirializarXML(typeof(string), "Data/itensTxt/" + j + "itensTxt.meme") != null) {
                    txt.Text = saveLoad.DesirializarXML(typeof(string), "Data/itensTxt/" + j + "itensTxt.meme").ToString();
                    j++;
            //    }
            }

            //Carrega a quantidade de cada item
            j = 0;
            foreach (TextBox qnt in textBoxesQntList) {
            //    if(saveLoad.DesirializarXML(typeof(string), "Data/itensQnt/" + j + "itensQnt.meme") != null) {
                    qnt.Text = saveLoad.DesirializarXML(typeof(string), "Data/itensQnt/" + j + "itensQnt.meme").ToString();
                    j++;
            //    }
            }

            j = 0;
            foreach (TextBox magic in textBoxesMagic) {
                magic.Text = saveLoad.DesirializarXML(typeof(string), "Data/magic/" + j + "magicName.meme").ToString();
                j++;
            }

            j = 0;
            foreach (TextBox magicCu in textBoxesMagicCusto) {
                magicCu.Text = saveLoad.DesirializarXML(typeof(string), "Data/magic/" + j + "magicCu.meme").ToString();
                j++;
            }


        }

        public class SerializadorDeData
        {
            //Vai tomar no cu serialização
            public void SerializarXML(Type tipoData, object objeto, string caminhoArquivo) {
                XmlSerializer xmls = new XmlSerializer(tipoData);
                if (File.Exists(caminhoArquivo)) File.Delete(caminhoArquivo);
                TextWriter escrivao = new StreamWriter(caminhoArquivo);
                xmls.Serialize(escrivao, objeto);
                escrivao.Close();
            }

            public object DesirializarXML(Type tipoData, string caminhoArquivo) {
                object obj = 0;


                XmlSerializer xmls = new XmlSerializer(tipoData);

                if (File.Exists(caminhoArquivo)) {
                    TextReader txtr = new StreamReader(caminhoArquivo);
                    obj = xmls.Deserialize(txtr);
                }
                return obj;
            }

        }

    }
}


