namespace DP_ETL_TOOL.Entities
{
    class WhereConditionEntity
    {
        private string leftSide;
        private string rightSide;

        public WhereConditionEntity(string leftSide, string rightSide)
        {
            this.leftSide = leftSide;
            this.rightSide = rightSide;
        }

        public void SetLeftSideCondition(string leftSide)
        {
            this.leftSide = leftSide.ToUpper().Trim();
        }

        public void SetRightSideCondition(string rightSide)
        {
            this.rightSide = rightSide.ToUpper().Trim();
        }

        public string GetLeftSideCondition()
        {
            return this.leftSide;
        }

        public string GetRighttSideCondition()
        {
            return this.rightSide;
        }
    }
}
