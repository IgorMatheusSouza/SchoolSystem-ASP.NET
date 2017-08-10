using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
 
namespace SchoolSystem
{
    public partial class Default : System.Web.UI.Page
    {



        private ModelDataContext mdc;


        protected void Page_Load(object sender, EventArgs e)
        {
            // lblDataCadastro.Text = DateTime.Now.ToShortDateString();   

            if (!IsPostBack) {
                this.populateGrid();
            
            }

        }


        private void populateGrid() {
            mdc = new ModelDataContext();
            try
            {

                var sourceMateria = from mat in mdc.Materias
                                    select mat;

                gwDados.DataSource = sourceMateria;
                gwDados.DataBind();




            }
            catch (Exception)
            {
                throw;
            }
            finally {
                mdc.Dispose();

            }

        
        }
    }
}