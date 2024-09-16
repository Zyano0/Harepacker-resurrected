﻿using MapleLib.WzLib.WzProperties;
using MapleLib.WzLib.WzStructure.Data.QuestStructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HaCreator.Converter
{
    public class QuestStateIdToQuestStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is QuestStateType questState)
            {
                return questState.ToReadableString();
            }
            return QuestStateType.Not_Started.ToReadableString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string questState)
            {
                return QuestStateTypeExtensions.ToEnum(questState);
            }
            return QuestStateType.Not_Started;
        }
    }
}