namespace StudentSystem.MVVM.ViewModel
{
    public interface IViewModel
    {
        IViewModel CurrentViewModel { get; set; }
        IViewModel CurrentViewModelParent { get; set; }
    }
}