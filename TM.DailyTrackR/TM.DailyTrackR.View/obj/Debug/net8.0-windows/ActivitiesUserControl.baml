   M S B A M L   `   `   `  ����N  JTM.DailyTrackR.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TM.DailyTrackR.ViewTM.DailyTrackR.View  5      /    )TM.DailyTrackR.View.ActivitiesUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TM.DailyTrackR.View     5      .��5	      �� .@�5
      �� $��Daily��6   .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�5      $��Center=�5      .+�5      �� $��Selected date: ��6   �� 5      ��6   �� *SelectedDate+ �� StringFormat$ 
dd-MM-yyyy��5      �� 5      $��1��6   $��+��5      $��5q�5      $��2q�5      
����·���5!      �� *AddActivityCommand+ � 	Resources 5"       �� 
TargetType �� Property �� Value��%_   '��       �� 5#      " ��6   .�5$      ��  �@��CornerRadius$ 10��61   5%      5&      5'      5(      &   System.Windows.Controls.DataGrid  5)   
   $��1��6   ��5*      �� *ActivitiesByDate+5+   	   5,      �� 5.      $��Overview��6   .��5/      �   50   
   �� 51      $
��Auto �6   �� 52      $��* �6   �� 53      $
��Auto �6   .+�56   
   �� $��0��6   $ 
Horizontal=�57      $��Center=�58      $	��0 8q�59      .+�5:      �� $��Selected date: ��6   �� 5;      ��6   �� *SelectedDate+$ 
dd-MM-yyyy��5<        5>   
   $��1��6   ��5?      �� *AllActivities+�� 5A   
   $��2��6   $ 
Horizontal=�5B      $��Center=�5C      $��5q�5D      .+�5E      �� $��Export activity in ��6   (  "System.Windows.Controls.DatePicker  5F      �� 5G      $�� period of time. ��6   �� 5H      $��Export��6   5I      5J   	   5K      5L      5M      