using System.Runtime.Serialization;

namespace DP_ETL_TOOL.Entities
{
    [DataContract]
    class GUICoordsEntity
    {
        [DataMember]
        private int posX;
        [DataMember]
        private int posY;
        [DataMember]
        private int width;
        [DataMember]
        private int height;

        public GUICoordsEntity()
        {
            
        }

        public GUICoordsEntity(int posX, int posY, int width, int height) {
            this.posX = posX;
            this.posY = posY;
            this.width = width;
            this.height = height;
        }

        public void SetPosX(int posX)
        {
            this.posX = posX;
        }

        public void SetPosY(int posY)
        {
            this.posY = posY;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        public int GetPosX()
        {
            return this.posX;
        }

        public int GetPosY()
        {
            return this.posY;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public int GetHeight()
        {
            return this.height;
        }
    }
}
