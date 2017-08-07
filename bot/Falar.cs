using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace bot
{
    class Falar
    {
        protected SpeechSynthesizer Speaker { get; set; }

        public Falar()
        {

            Speaker = new SpeechSynthesizer();

            var z = "";
            foreach (var item in IdiomasDisponiveis().Where(item => item.Contains("pt-BR")))
            {
                z = item;
                return;
            }
            Speaker.SelectVoice(z);
        }


        private IEnumerable<string> IdiomasDisponiveis()
        {
            return Speaker.GetInstalledVoices().Select(voice => voice.VoiceInfo.Culture.ToString()).ToList();
        }

        public void Sintetizar(string Texto)
        {
            Speaker.SpeakAsync(Texto);
        }

        public void Pausar()
        {
            Speaker.Pause();
        }

        public void Continuar()
        {
            Speaker.Resume();
        }
    }
}
