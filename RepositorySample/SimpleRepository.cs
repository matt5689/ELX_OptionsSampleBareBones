using System.Linq;

namespace RepositorySample
{
    public class SimpleRepository : GenericRepository<SimpleClassObject>
    {
        public SimpleRepository(DataContext context) : base(context)
        {
        }

        public override SimpleClassObject AddOneToLastSimpleClassItemValue(SimpleClassObject simpleClassItem)
        {
            var myClassItemEdit = context.RepoOneObjects.Last();

            myClassItemEdit.Value += 1;

            return base.AddOneToLastSimpleClassItemValue(myClassItemEdit);
        }
    }
}