using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;  //usaundo o banco na pagina
namespace SchoolSystem
{
    public partial class Materias_Add : System.Web.UI.Page
    {   


        ModelDataContext mdc;
        protected void Page_Load(object sender, EventArgs e)
         {
             tbDataCadastro.Text = DateTime.Now.ToShortDateString();
        
        }

        //Função do click cadastrar
        protected void btnCadastrar_Click(object obj, EventArgs e) { 
        this.onInsert();
        }




        //Insert materias no banco de dados 
        private void onInsert(){
            mdc = new ModelDataContext();
            //mdc=Banco de Dados

             try 
	         {
                 Materia materia = new Materia();
                 materia.Nome = tbNome.Text.Trim();
                 materia.Descricao = tbDescriao.Text.Trim();
                 materia.dataCadastro = Convert.ToDateTime(tbDataCadastro.Text.Trim());


                 mdc.Materias.InsertOnSubmit(materia);
                 mdc.SubmitChanges();

                 Response.Redirect("materias.aspx");
	         }
	         catch (Exception)
	         {
		
		         throw;
	         }

          
            finally{
                 }
    
        }


    }


}