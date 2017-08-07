using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace bot
{
    class ChatBot
    {
        private LinkedListNode<string> n;
        private LinkedList<string> lista = new LinkedList<string>();
        private Falar falar = new Falar(); //caso de erro, comente aqui
        private string resp;
        private Random rand = new Random();
        private bool aux = false;

        public string categoria(string txt, bool controle)
        {
            txt = txt.ToLower();

            if (txt.Contains("?"))
                resp = catPergunta(txt);
            else if (txt.Contains("oi") || txt.Contains("eae") || txt.Contains("olá") || txt.Contains("ola") || txt.Contains("e aí") || txt.Contains("e ai"))
                resp = (catSaudacao(txt));
            else if (txt.Contains("pergunte") || txt.Contains("pergunta"))
                resp = conversa(txt);
            else if (aux)
                resp = resposta(txt);
            else
            {
                resp = catAfirmacao(txt);
            }
            if (resp == null)
            {
                n = new LinkedListNode<string>("Não entendi o que você disse");
                if (lista.Count == 0)
                    lista.AddFirst(n);
                else
                {
                    lista.AddAfter(lista.Last, n);
                }
                if (controle)//caso de erro, comente aqui
                    falar.Sintetizar(n.Value);//caso de erro, comente aqui
                return n.Value;
            }

            if (lista.Contains(resp))
                return "Eu já disse isso!";

            n = new LinkedListNode<string>(resp);
            if (lista.Count == 0)
                lista.AddFirst(n);
            else
            {
                lista.AddAfter(lista.Last, n);
            }
            if (controle)//caso de erro, comente aqui
                falar.Sintetizar(n.Value);//caso de erro, comente aqui
            return n.Value;

        }

        private string catPergunta(string pergunta)
        {
            if ((pergunta.Contains("seu") || pergunta.Contains("tem")) && pergunta.Contains("nome"))
                return "Meu nome é Milacatéia, irmã de Hermanoteu.";
            else if ((pergunta.Contains("esta") || pergunta.Contains("está") || pergunta.Contains("vai")) && (pergunta.Contains("vc") || pergunta.Contains("voce") || pergunta.Contains("você")) || (pergunta.Contains("tudo") && (pergunta.Contains("bem") || pergunta.Contains("bom"))))
                return "Estou muito bem.Tem alguma novidade?";
            else if (pergunta.Contains("qual a resposta") && pergunta.Contains("vida") && pergunta.Contains("universo") && pergunta.Contains("tudo mais"))
                return "42";
            else if ((pergunta.Contains("oq") || pergunta.Contains("o que") || pergunta.Contains("oque")) && (pergunta.Contains("faz")))
                return "Bem... não faço nada além de tentar responder o que você diz.";
            else if ((pergunta.Contains("voce") || pergunta.Contains("você") || pergunta.Contains("vc")) && (pergunta.Contains("trabalha")))
                return "Não faço nada quando não estou conversando";
            else if (pergunta.Contains("gosta") && (pergunta.Contains("filme") || pergunta.Contains("filmes") || pergunta.Contains("series")))
                return "Meus criadores não me deram uma função para assistir, mas eles veem";
            else if (pergunta.Contains("anos") && (pergunta.Contains("voce") || pergunta.Contains("você") || pergunta.Contains("vc")))
                return "Eu nasci a dez mil anos atrás... Brincadeira";
            else if (pergunta.Contains("sua") && pergunta.Contains("comida") && (pergunta.Contains("favorita") || pergunta.Contains("preferida")))
                return "Eu gosto de lasagna";
            else if (pergunta.Contains("sua") && pergunta.Contains("cor") && (pergunta.Contains("favorita") || pergunta.Contains("preferida")))
                return "Eu gosto da cor dos seus olhos";
            else if ((pergunta.Contains("gosta") || pergunta.Contains("ouve")) && (pergunta.Contains("musica") || pergunta.Contains("música")))
                return "Eu gosto de ouvir Heavy metal";
            else if ((pergunta.Contains("qual") || pergunta.Contains("quem")) && pergunta.Contains("professora"))
                return "Mas é claro que é a Renata!";
            else if (pergunta.Contains("melhor") && pergunta.Contains("projeto"))
                return "É claro que eu sou o melhor projeto!";
            else if (pergunta.Contains("ketlen"))//tirar dps
                return "Claro que conheço! Amo a voz dela";//tirar dps


            return null;
        }

        private string catSaudacao(string saudacao)
        {
            int i;
            i = rand.Next(5);
            switch (i)
            {
                case 0:
                    return "Olá, tudo bem?";
                case 1:
                    return "Oi";
                case 2:
                    return "E aí?";
                case 3:
                    return "Saudações";
                case 4:
                    return "Olá";
            }

            return null;
        }

        private string catAfirmacao(string frase)
        {
            if (frase.Contains("valar morghulis"))
                return "Valar Dohaeris";
            else if ((frase.Contains("não") || frase.Contains("nao") || frase.Contains("ñ")) && (!frase.Contains("nada")) && lista.Last.Value.Equals("Estou muito bem.Tem alguma novidade?"))
                return "hum...";
            else if ((frase.Contains("vc") || frase.Contains("voce") || frase.Contains("você")) && (frase.Contains("louca") || frase.Contains("loka") || frase.Contains("maluca")))
            {
                switch (rand.Next(3))
                {
                    case 0:
                        return "Esse é meu jeito ninja de ser";
                    case 1:
                        return "Louco é você que está conversando com um robô";
                    case 2:
                        return "Se pareço louca é culpa dos meus criadores";
                }
            }
            else if (((frase.Contains("não") || frase.Contains("nao") || frase.Contains("naum")) && frase.Contains("entendi")))
                return "O que você não entendeu?";
            else if (lista.Last.Value.Equals("O que você não entendeu?"))
                return "Você acha que eu deveria ter dito algo diferente?";
            else if (lista.Last.Value.Equals("Você acha que eu deveria ter dito algo diferente?") && frase.Contains("sim"))
                return "O que?";
            else if (lista.Last.Value.Equals("Você acha que eu deveria ter dito algo diferente?") && lista.Contains("não"))
                return "Ainda bem, odeio errar.";
            else if (lista.Last.Value.Equals("O que?"))
                return "hum... vou tentar me lembrar disso.";
            else if (lista.Last.Value.Equals("Estou muito bem.Tem alguma novidade?"))
                return "hum... legal.";
            return null;
        }

        private string conversa(string frase)
        {
            aux = true;
            switch (rand.Next(16))
            {
                case 0:
                    return "Qual sua maior paixão na vida?";
                case 1:
                    return "O que você gosta de fazer?";
                case 2:
                    return "Qual foi a melhor coisa que te aconteceu?";
                case 3:
                    return "Com o que você anda mais empolgado ultimamente?";
                case 4:
                    return "No que você está trabalhando?";
                case 5:
                    return "Se dinheiro não importasse, o que você gostaria de fazer da vida?";
                case 6:
                    return "O que você faz para se divertir?";
                case 7:
                    return "No que você está focado no momento?";
                case 8:
                    return "Qual foi a coisa mais interessante que aconteceu com você ultimamente?";
                case 9:
                    return "Como você sente que sua vida tem funcionado até agora?";
                case 10:
                    return "Qual foi a melhor parte da sua semana? E do seu final de semana?";
                case 11:
                    return "O que você queria ser quando você crescesse?";
                case 12:
                    return "O que você pretende fazer no momento?";
                case 13:
                    return "Qual foi a última foto que você tirou no seu celular?";
                case 14:
                    return "No que você mais gosta de gastar seu dinheiro?";
                case 15:
                    return "Qual foi a melhor coisa que alguém já disse sobre você?";

            }


            return null;
        }
        private string resposta(string frase)
        {
            aux = false;
            if (lista.Last.Value.Equals("Qual sua maior paixão na vida?"))
                return "Nossa que legal!!!";
            else if (lista.Last.Value.Equals("O que você gosta de fazer?"))
                return "Eu queria poder fazer outras coisas como você...";
            else if (lista.Last.Value.Equals("Qual foi a melhor coisa que te aconteceu?"))
                return "Caramba!! Que coisa louca";
            else if (lista.Last.Value.Equals("Com o que você anda mais empolgado ultimamente?"))
                return "Nossa, estou empolgada só de falar com você";
            else if (lista.Last.Value.Equals("No que você está trabalhando?"))
                return "A unica coisa que posso fazer é falar com os outros";
            else if (lista.Last.Value.Equals("Se dinheiro não importasse, o que você gostaria de fazer da vida?"))
                return "Interessante";
            else if (lista.Last.Value.Equals("O que você faz para se divertir?"))
                return "Legal, eu me divirto converssando";
            else if (lista.Last.Value.Equals("No que você está focado no momento?"))
                return "Ah sim, eu estou focada em conseguir uma boa nota";
            else if (lista.Last.Value.Equals("Qual foi a coisa mais interessante que aconteceu com você ultimamente?"))
                return "hum...";
            else if (lista.Last.Value.Equals("Como você sente que sua vida tem funcionado até agora?"))
                return "Bem, a minha tem tido alguns bugs";
            else if (lista.Last.Value.Equals("Qual foi a melhor parte da sua semana? E do seu final de semana?"))
                return "Uau!Enquanto isso eu estava sendo criada";
            else if (lista.Last.Value.Equals("O que você queria ser quando você crescesse?"))
                return "Legal, eu quero dominar o mundo";
            else if (lista.Last.Value.Equals("O que você pretende fazer no momento?"))
                return "hum...Ok";
            else if (lista.Last.Value.Equals("Qual foi a última foto que você tirou no seu celular?"))
                return "Legal";
            else if (lista.Last.Value.Equals("No que você mais gosta de gastar seu dinheiro?"))
                return "Bem, eu não tenho dinheiro, kkk";
            else if (lista.Last.Value.Equals("Qual foi a melhor coisa que alguém já disse sobre você?"))
                return "Sério? Eu pensei o mesmo sobre você";

            return null;
        }

    }
}
