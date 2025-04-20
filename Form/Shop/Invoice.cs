using System.Windows.Forms;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM
{
    public partial class Invoice : Form
    {
        public Invoice(string email, MongoClient client)
        {
            InitializeComponent();
        }
    }
}