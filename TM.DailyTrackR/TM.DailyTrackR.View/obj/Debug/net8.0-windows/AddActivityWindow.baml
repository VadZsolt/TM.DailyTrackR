   M S B A M L   `   `   `  ����N  JTM.DailyTrackR.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TM.DailyTrackR.ViewTM.DailyTrackR.View  5   	   +    %TM.DailyTrackR.View.AddActivityWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TM.DailyTrackR.View     5   	     � Title$  AddActivityWindow��5   	   $	��300��5	   	   $	��500��5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � RowDefinitions 5      �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $��* �6   �� 5   
   $
��Auto �6   .+�5      � $��0��6   $��5q�5      $��Center=�5       � ColumnDefinitions 5      �� 5   
   $��3* �6   �� 5   
   $��8* �6   .+�5      �� $��Project Type��6   $��0��5      �� 5      $��1��6   5       � 5"      $��1��6   $��5q�5#      $��Center=�5$       5%      �� 5&   
   $��3* �6   �� 5'   
   $��8* �6   .+�5)      �� $��	Task Type��6   $��0��5*      �� 5+      $��1��6   5,      � 5.      $��2��6   $��5q�5/      $��Center=�50       51      �� 52   
   $��3* �6   �� 53   
   $��8* �6   .+�55      �� $��Description��6   $��0��56      �� 57      $��1��6   58      � 5:      $��3��6   $��5q�5;      $��Center=�5<       5=      �� 5>   
   $��3* �6   �� 5?   
   $��8* �6   .+�5A      �� $��Status��6   $��0��5B      �� 5C      $��1��6   5D      � 5F      $��4��6   $��5q�5G      $��Center=�5H       5I      �� 5J   
   $��3* �6   �� 5K   
   $��8* �6   .+�5M      �� $
��Date��6   $��0��5N      (  "System.Windows.Controls.DatePicker  5O      $��1��6   5P      � 5R      $��5��6   $��5q�5S       5T      �� 5U   
   $��8* �6   �� 5V   
   $��2* �6   .+�5X      �� $��1��6   $
��Save��6   5Y      5Z      5[      