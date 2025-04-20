using System.Windows.Forms;
using MongoDB.Driver;

namespace MDBMS___E_COMMERCE_PLATFORM
{
    public partial class Storage : Form
    {
        public Storage(string email, MongoClient client)
        {
            InitializeComponent();
        }
    }
}