﻿using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WindowsFormsApp1
{

    internal class Class_BD_CRUD
    {   //"server=localhost;port=3307;User Id=root;database=projeto_registro_sql;password=usbw"
        //"server=containers-us-west-156.railway.app;port=6863;User Id=root;database=railway;password=uoNk5WCFgcxKJ1AjalxJ"
        private MySqlConnection conn = new MySqlConnection("server=containers-us-west-156.railway.app;port=6863;User Id=root;database=railway;password=uoNk5WCFgcxKJ1AjalxJ");
        private int id_hora, id_data, id_americanas;
        public Class_BD_CRUD() 
        {
            /* campo vazio, abertura do BD sera manual
             MessageBox.Show("Banco de Dados public inicializado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);*/
        }
        public void setBD_Open()
        {
            //abre o BD
            conn.Open();
            MessageBox.Show("Banco de Dados open.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public void setBD_Close() 
        {
            //fecha o BD
            conn.Close();
            MessageBox.Show("BD fechado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void setInputBd_titular (string cpf_titular, string nome, string email, string telefone)
        {
            MySqlCommand objcmd_titular = new MySqlCommand("insert into titular (cpf_titular, nome, email, telefone) values (?, ?, ?, ?)", conn);
            // parametros para o sql titular
            objcmd_titular.Parameters.Add("@cpf_titular", MySqlDbType.VarChar, 15).Value = cpf_titular;
            objcmd_titular.Parameters.Add("@nome", MySqlDbType.VarChar, 75).Value = nome;
            objcmd_titular.Parameters.Add("@email", MySqlDbType.VarChar, 30).Value = email;
            objcmd_titular.Parameters.Add("@telefone", MySqlDbType.VarChar, 15).Value = telefone;
            // executando querys            
            objcmd_titular.ExecuteNonQuery();
            MessageBox.Show("envio de dados titular ok.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void setInputBd_data(string chegada_data, string retirada_data)
        {
            MySqlCommand objcmd_data = new MySqlCommand("insert into tbl_data (id_data, chegada_data, retirada_data) values (NULL, ?, ?)", conn);
            // parametros para o sql data
            objcmd_data.Parameters.Add("@chegada_data", MySqlDbType.VarChar, 10).Value = chegada_data;
            objcmd_data.Parameters.Add("@retirada_data", MySqlDbType.VarChar, 10).Value = retirada_data;
            // executando query                       
            objcmd_data.ExecuteNonQuery();
            MessageBox.Show("envio de dados data ok.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
            id_data = Convert.ToInt32(objcmd_data.ExecuteScalar());
        }
        
        public void setInputBd_hora(string chegada_hora, string retirada_hora)
        {
            MySqlCommand objcmd_hora = new MySqlCommand("insert into hora (id_hora, chegada_hora, retirada_hora) values (NULL, ?, ?)", conn);
            // parametros para o sql hora
            objcmd_hora.Parameters.Add("@chegada_hora", MySqlDbType.VarChar, 10).Value = chegada_hora;
            objcmd_hora.Parameters.Add("@retirada_hora", MySqlDbType.VarChar, 10).Value = retirada_hora;
            // executando query                       
            objcmd_hora.ExecuteNonQuery();
            MessageBox.Show("envio de dados hora ok.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            id_hora = Convert.ToInt32(objcmd_hora.ExecuteScalar());
        }

        public void setInputBd_americanas (int cep_americanas, string rua_americanas, string bairro_americanas, int numero_americanas)
        {
            MySqlCommand objcmd_americanas = new MySqlCommand("INSERT INTO americanas (id_americanas, cep_americanas, rua_americanas, bairro_americanas, numero_americanas) VALUES (NULL, ?, ?, ?, ?)", conn);
            // parametros para o sql pacote
            objcmd_americanas.Parameters.Add("@cep_endereco", MySqlDbType.VarChar, 15).Value = cep_americanas;
            objcmd_americanas.Parameters.Add("@rua_endereco", MySqlDbType.VarChar, 45).Value = rua_americanas;
            objcmd_americanas.Parameters.Add("@bairro_endereco", MySqlDbType.VarChar, 15).Value = bairro_americanas;
            objcmd_americanas.Parameters.Add("@numero_endereco", MySqlDbType.Int32).Value = numero_americanas;
            // executando query                       
            objcmd_americanas.ExecuteNonQuery();
            MessageBox.Show("envio de dados americanas ok.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            id_americanas = Convert.ToInt32(objcmd_americanas.ExecuteScalar());
        }

        public void setInputBd_funcionario (string email_funcionario, string cpf_funcionario, string nome_funcionario, string telefone_funcionario, string cargo_funcionario, string senha_funcionario)
        {
            MySqlCommand objcmd_funcionario = new MySqlCommand("INSERT INTO funcionario (email_americanas_funcionario, cpf_funcionario, nome_funcionario, telefone_funcionario, cargo_funcionario, senha_funcionario, id_americanas) VALUES (?, ?, ?, ?, ?, ?, ?)", conn);
            // parametros para o sql pacote

            objcmd_funcionario.Parameters.Add("@email_americanas_funcionario", MySqlDbType.VarChar, 255).Value = email_funcionario;
            objcmd_funcionario.Parameters.Add("@cpf_funcionario", MySqlDbType.VarChar, 15).Value = cpf_funcionario;
            objcmd_funcionario.Parameters.Add("@nome_funcionario", MySqlDbType.VarChar, 45).Value = nome_funcionario;
            objcmd_funcionario.Parameters.Add("@telefone_funcionario", MySqlDbType.VarChar, 15).Value = telefone_funcionario;
            objcmd_funcionario.Parameters.Add("@cargo_funcionario", MySqlDbType.Int32).Value = cargo_funcionario;
            objcmd_funcionario.Parameters.Add("@senha_funcionario", MySqlDbType.Int32).Value = senha_funcionario;
            objcmd_funcionario.Parameters.Add("@id_americanas", MySqlDbType.Int32).Value = id_americanas;
            // executando query                       
            objcmd_funcionario.ExecuteNonQuery();
            MessageBox.Show("envio de dados funcionario ok.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void setInputBd_pacote(string nota_fiscal, string situacao_pacote, string email_americanas_funcionario, string cpf_titular, string cpf_entregador)
        {
            MySqlCommand objcmd_pacote = new MySqlCommand("INSERT INTO pacote (nota_fiscal_pacote, situacao_pacote, email_americanas_funcionario, cpf_titular, cpf_entregador, id_data, id_hora) VALUES (?, ?, ?, ?, ?, ?, ?); SELECT LAST_INSERT_ID();", conn);

            objcmd_pacote.Parameters.Add("@nota_fiscal_pacote", MySqlDbType.VarChar, 45).Value = nota_fiscal;
            objcmd_pacote.Parameters.Add("@situacao_pacote", MySqlDbType.VarChar, 20).Value = situacao_pacote;
            objcmd_pacote.Parameters.Add("@email_americanas_funcionario", MySqlDbType.VarChar, 255).Value = email_americanas_funcionario;
            objcmd_pacote.Parameters.Add("@cpf_titular", MySqlDbType.VarChar, 15).Value = cpf_titular;
            objcmd_pacote.Parameters.Add("@cpf_entregador", MySqlDbType.VarChar, 15).Value = cpf_entregador;
            objcmd_pacote.Parameters.Add("@id_data", MySqlDbType.VarChar, 15).Value = id_data;
            objcmd_pacote.Parameters.Add("@id_hora", MySqlDbType.VarChar, 15).Value = id_hora;

            // Executar a consulta de inserção e recuperar o ID gerado automaticamente
            objcmd_pacote.ExecuteNonQuery();
            MessageBox.Show("Envio de dados pacote ok.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public bool setReadBd_login(string usuario, string senha)
        {
            // Construa a consulta SQL para verificar as credenciais do usuário
            string query = "SELECT COUNT(*) FROM funcionario WHERE email_americanas_funcionario = @usuario AND senha_funcionario = @senha";

            MySqlCommand objcmd_login = new MySqlCommand(query, conn);
            objcmd_login.Parameters.Add("@usuario", MySqlDbType.VarChar, 255).Value = usuario;
            objcmd_login.Parameters.Add("@senha", MySqlDbType.VarChar, 32).Value = senha; // Certifique-se de usar o mesmo tipo de dados que está armazenado no banco de dados para senhas.

            // Execute a consulta para verificar as credenciais
            int result = Convert.ToInt32(objcmd_login.ExecuteScalar());

            if (result > 0)
            {
                MessageBox.Show("Login bem-sucedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true; // As credenciais são válidas
            }
            else
            {
                MessageBox.Show("Credenciais inválidas. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // As credenciais são inválidas
            }
        }

        public User setReadBd_user(string usuario, string senha)
        {
            string query = "SELECT * FROM funcionario WHERE email_americanas_funcionario = @usuario AND senha_funcionario = @senha";

            MySqlCommand objcmd_user = new MySqlCommand(query, conn);
            objcmd_user.Parameters.Add("@usuario", MySqlDbType.VarChar, 255).Value = usuario;
            objcmd_user.Parameters.Add("@senha", MySqlDbType.VarChar, 32).Value = senha;

            using (MySqlDataReader reader = objcmd_user.ExecuteReader())
            {
                if (reader.Read())
                {
                    string email, cpf, nome, telefone, cargo;
                    int id_americanas;

                    email = reader["email_americanas_funcionario"].ToString();
                    cpf = reader["cpf_funcionario"].ToString();
                    nome = reader["nome_funcionario"].ToString();
                    telefone = reader["telefone_funcionario"].ToString();
                    cargo = reader["cargo_funcionario"].ToString();
                    id_americanas = Convert.ToInt32(reader["id_americanas"]);

                    User funcionario = new User(nome, email, senha);
                    
                    return funcionario;
                }
            }

            // Se não encontrou um funcionário com as credenciais fornecidas, retorne null
            return null;
        }
    }
}
