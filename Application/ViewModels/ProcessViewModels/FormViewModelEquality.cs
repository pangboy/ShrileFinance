namespace Application.ViewModels.ProcessViewModels
{
    using System.Collections.Generic;

    public class FormViewModelEquality : IEqualityComparer<FormViewModel>
    {
        public bool Equals(FormViewModel x, FormViewModel y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(FormViewModel obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
