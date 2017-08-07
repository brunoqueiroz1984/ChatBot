using System;
using System.Collections.Generic;

namespace Editor
{
    // Classe para o editor de texto
    public class Text
    {
        // Atributos e propriedades
        private LinkedList<string> listaTexto;
        
        // Retorna a primeira linha do texto
        public LinkedListNode<string> FirstLine
        {
            get { return listaTexto.First; }
        }

        // N�mero de linhas do texto
        public int NumLines
        {
            get { return listaTexto.Count; }
        }

        // Construtor
        public Text()
        {
            listaTexto = new LinkedList<string>();
        }

        // Nova linha: o valor -1 indica que o elemento deve ser 
        // inserido na primeira posi��o
        // Outros valores indicam a posi��o ap�s a qual o novo elmento ser�
        // inserido, ininciando em 0
        public void InsertLine(string text, int position)
        {
            // Primeiro

            if (position == -1)
                listaTexto.AddFirst(text);

            else
            {
                LinkedListNode<string> p = new LinkedListNode<string>(text);
                listaTexto.AddAfter(listaTexto.Last, text);
            }
            
        }


    }

}
