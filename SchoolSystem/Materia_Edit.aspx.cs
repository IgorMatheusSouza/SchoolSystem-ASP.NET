using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace SchoolSystem
{
    public partial class Materia_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.populatefields(int.Parse(Request.QueryString["id"]));
            }
            catch (Exception)
            {

                this.populatefields();
            }
           
        }

        protected void bntAtualizar_Click(object sender, EventArgs e)
        {
            this.onUpdate();

        
      }

        private void onUpdate() {


            ModelDataContext mdc = new ModelDataContext();

            try
            {


                Materia materia = mdc.Materias.First(mat => mat.idMateria == int.Parse(tbCodMateria.Text.Trim()));
                materia.Nome = tabelanome.Text.Trim();
                materia.Descricao = tbdescricao.Text.Trim();
                materia.dataAtualizacao = DateTime.Parse(DateTime.Now.ToShortDateString());
                mdc.SubmitChanges();
                Response.Redirect("Materias.aspx");

            }

            catch (Exception)
            {
            }
            finally {
                mdc.Dispose();

            }

        }

        private void populatefields(int pGetID = 0) {

            ModelDataContext mdc = new ModelDataContext();

            try
            {

                if (pGetID > 0)
                {
                    Materia materia = mdc.Materias.First(mat => mat.idMateria == pGetID);

                    tbCodMateria.Text = pGetID.ToString();
                    



                }


                else
                {

                    Response.Redirect("Materias.aspx");
                }

            }
            catch (Exception) { 
            }

        }
    }
}