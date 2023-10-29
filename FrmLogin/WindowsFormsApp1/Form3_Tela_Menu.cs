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
using MySql.Data.MySqlClient;
using WindowsFormsApp1.lista.presentes;
using WindowsFormsApp1.lista.retirados;
using WindowsFormsApp1.lista.Recebidos_Retirados_nodia;

namespace WindowsFormsApp1
{
    public partial class Form3_Tela_Menu : Form
    {
        Thread t2;
        public Form3_Tela_Menu()
        {
            InitializeComponent();
        }
        
        private void trocarUsuárioToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void adicionarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            t2 = new Thread(abrirCadastrarUsuario);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }


        private void abrirCadastrarUsuario(object obj)
        {
            Application.Run(new FormCadastroUser());
        }

        private void registroToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            t2 = new Thread(abrirRegistroPac);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }
        
        private void abrirRegistroPac(object obj)
        {
            Application.Run(new RegistrosPac.Form5_Registro_Pac());
        }
        
        private void geralToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            t2 = new Thread(abrirLista);
            t2.SetApartmentState(ApartmentState.MTA);
            t2.Start();
        }
               
        private void abrirLista(object obj)
        {
            Application.Run(new lista.Geral.Form6_Lista_Geral());
        }

        private void Form3_Tela_Menu_Load(object sender, EventArgs e)
        {
            try
            {
                /*
                // string de conexão BD
                var strConnection = "server=containers-us-west-156.railway.app;port=6863;User Id=root;database=railway;password=uoNk5WCFgcxKJ1AjalxJ";
                MySqlConnection conn = new MySqlConnection(strConnection);
                //abre o BD
                conn.Open();
                MessageBox.Show("conectado BD.");
                //fecha o BD
                conn.Close();
                */
                Class_BD_CRUD server = new Class_BD_CRUD();
                
            }
            catch 
            {
                MessageBox.Show("Erro ao conectar com o banco de dados.", "Data Base");                
            }           

        }

        private void recebidosNoDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t2 = new Thread(Presentes);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }
        private void Presentes(object obj)
        {
            Application.Run(new Form7_Tela_Presentes());
        }

        private void retiradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t2 = new Thread(Retirados);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }
        private void Retirados(object obj)
        {
            Application.Run(new Form8_Tela_Retirados());
        }

        private void recebidosNoDiaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            t2 = new Thread(RecebidosDoDia);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }
        private void RecebidosDoDia(object obj)
        {
            Application.Run(new Form9_recebidos_retirados_nodia());
        }
        private void retiradosNoDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t2 = new Thread(RetiradosDoDia);
            t2.SetApartmentState(ApartmentState.STA);
            t2.Start();
        }
        private void RetiradosDoDia(Object obj)
        {
            Application.Run(new Form9_recebidos_retirados_nodia());
        }

    }
}
