using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class MagazineCollection
    {
        private List<Magazine> _magazines;

        public MagazineCollection()
        {
            _magazines = new List<Magazine>();
        }
        public void AddDefaults()
        {
            _magazines.Add(new Magazine("New-York Times", Frequency.Weekly, new DateTime(2009, 12, 11), 25000));
            _magazines.Add(new Magazine("Daily Bugles", Frequency.Monthly, new DateTime(2012, 1, 1), 200000));
        }

        public void AddMagazines(params Magazine[] magazines)
        {
            _magazines.AddRange(magazines);
        }


        public override string ToString()
        {
            return
                $"{nameof(_magazines)}: {string.Join(", ", (from Magazine magazine in _magazines select magazine.ToString()).ToArray())}";
        }

        public virtual string ToShortString()
        {
            return
                $"{nameof(_magazines)}: {string.Join(", ", (from Magazine magazine in _magazines select magazine.ToShortString()).ToArray())}";
        }

        public void SortByName()
        {
            _magazines.Sort();
        }

        public void SortByDate()
        {
            _magazines.Sort(new Edition());

        }

        public void SortByCopiesCount()
        {
            _magazines.Sort(new EditionByCopiesCountComparer());
        }

        public double MaxAvgRate
        {
            get
            {
                if (_magazines.Count == 0) return default;

                return (from Magazine magazine in _magazines select magazine.Rating).Max();
            }
        }

        public IEnumerable<Magazine> MonthlyMagazines => (from Magazine magazine in _magazines select magazine)
            .Where(magazine => magazine.Frequency == Frequency.Monthly);

        public List<Magazine> RatingGroup(double value)
        {
            var ratingQry = from Magazine magazine in _magazines
                            where magazine.Rating >= value
                            group magazine by magazine.Rating;

            return ratingQry.SelectMany(group => group).ToList();
        }
    }
}
