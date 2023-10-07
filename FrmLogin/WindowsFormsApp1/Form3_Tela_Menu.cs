﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;


namespace WindowsFormsApp1
{
    public partial class Form3_Tela_Menu : Form
    {
        Thread t2;
        public Form3_Tela_Menu()
        {
            InitializeComponent();
        }
        private void trocarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            t2 = new Thread(abrirLogin);
            t2.SetApartmentState(ApartmentState.MTA);
            t2.Start();
        }

        private void abrirLogin(object obj)
        {
            Application.Run(new FrmLogin());
        }

        private void adicionarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            t2 = new Thread(abrirCadastrarUsuario);
            t2.SetApartmentState(ApartmentState.MTA);
            t2.Start();
        }

        private void abrirCadastrarUsuario (object obj)
        {
            Application.Run(new Cadastros.Form4TelaCadastrosUsers());
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            t2 = new Thread(abrirRegistroPac);
            t2.SetApartmentState(ApartmentState.MTA);
            t2.Start();
        }

        private void abrirRegistroPac(object obj)
        {
            Application.Run(new RegistrosPac.Form5_Registro_Pac());
        }

        private void geralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t2 = new Thread(abrirLista);
            t2.SetApartmentState(ApartmentState.MTA);
            t2.Start();
        }

        private void abrirLista (object obj)
        {
            Application.Run(new lista.Geral.Form6_Lista_Geral());
        }
    }
}
