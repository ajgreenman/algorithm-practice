namespace InterviewQuestions.Infrastructure
{
    public abstract class Question
    {
        private double _number;
        public double Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private int _argumentCount;
        public int ArgumentCount
        {
            get { return _argumentCount; }
            set { _argumentCount = value; }
        }

        private int _algorithmCount;
        public int AlgorithmCount
        {
            get { return _algorithmCount; }
            set { _algorithmCount = value; }
        }

        public Question(double number, int argumentCount, int algorithmCount)
        {
            Number = number;
            ArgumentCount = argumentCount;
            AlgorithmCount = algorithmCount;
        }

        public abstract void Finisher(bool result, int algorithm, object[] arguments);
    }
}
