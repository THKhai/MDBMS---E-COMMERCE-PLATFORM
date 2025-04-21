using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM.Form.Shop
{
    public partial class Invoice : System.Windows.Forms.Form
    {
        public Invoice(string email, MongoClient client)
        {
            InitializeComponent();
        }
    }
}