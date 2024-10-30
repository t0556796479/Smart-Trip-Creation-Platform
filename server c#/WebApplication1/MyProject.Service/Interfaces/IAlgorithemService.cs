using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyProject.Common.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Interfaces
{
    public interface IAlgorithemService
    {
        //TODO: להוסיף תאור אלגוריתם
        public Task<List<TripObjectDto>> GetRoute(AlgorithemRequestDto algorithemRequest);

        public Task<List<PropertyFilterDto>> GetPropertiesByCategoryId(int categoryId);
    }
}
