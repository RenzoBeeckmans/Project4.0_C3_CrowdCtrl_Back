using Project4._0_C3_CrowdCtrl_Back.DAL;
using Project4._0_C3_CrowdCtrl_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project4._0_C3_CrowdCtrl_Back.Repositories
{
    public class MoodTypeRepository : GenericRepository<MoodType>
    {
        public MoodTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
