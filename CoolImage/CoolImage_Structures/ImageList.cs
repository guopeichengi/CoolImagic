/*这个类暂时没什么用。。用datatable代替
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CoolImage_Structures
{
    public class ImageList
    {
        private List<Image_Data> imageList;
        private long currentImageIndex;

        public ImageList(DataTable images)
        {
            if (images == null)
                return;

            imageList = new List<Image_Data>();

            int count = images.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                imageList.Add(new Image_Data());
                ConvertDataTableRowToImageListItem(images, ref imageList[i], i);
            }
        }

        public void GetImageByImageId(long imageId, ref Image_Data image_data)
        {
            if (images == null)
                return;

            for (int i = 0; i < imageList.Count; i++)
            {
                if (imageList[i].imageId == imageId)
                {
                    image_data = imageList[i];
                    currentImageIndex = i;
                    return;
                }
                
            }
        }

        public void GetNextImage(ref Image_Data image_data)
        {
            if (images == null)
                return;

            if (currentImageIndex + 1 > imageList.Count - 1)
                return;

            currentImageIndex++;
            image_data = imageList[currentImageIndex];
        }

        public void GetPreImage(ref Image_Data image_data)
        {
            if (images == null)
                return;

            if (currentImageIndex - 1 < 0)
                return;

            currentImageIndex--;
            image_data = imageList[currentImageIndex];
        }

        //辅助方法
        private void ConvertDataTableRowToImageListItem(DataTable dt, ref Image_Data image_data, int i)
        //转换dataTable一行数据至图片数据链
        {
            image_data.imageId = Convert.ToInt64(dt.Rows[i]["imageId"]);
            image_data.imageName = dt.Rows[i]["imageName"].ToString();
            image_data.imageUrl = dt.Rows[i]["imageUrl"].ToString();
            image_data.createDate = dt.Rows[i]["createDate"].ToString();
            image_data.descriptions = dt.Rows[i]["descriptions"].ToString();
            image_data.albumId = Convert.ToInt64(dt.Rows[i]["albumId"]);
        }
    }
}
*/