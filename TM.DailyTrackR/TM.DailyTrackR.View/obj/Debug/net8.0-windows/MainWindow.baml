   M S B A M L   `   `   `  ����N  JTM.DailyTrackR.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TM.DailyTrackR.ViewTM.DailyTrackR.View  5   	   R NTM.DailyTrackR.DataType, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:TM.DailyTrackR.DataType;assembly=TM.DailyTrackR.DataTypeTM.DailyTrackR.DataType 5   	   $    TM.DailyTrackR.View.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TM.DailyTrackR.View     5   	   ]
convertersFclr-namespace:TM.DailyTrackR.DataType;assembly=TM.DailyTrackR.DataType     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ TM Daily TrackR��5
   	    � Icon$ calendar.ico��5   	   $	��500��5   	   $	��800��5   	    � 
ResizeMode$ NoResize=�5   	   
������� J� InputBindings 5      �� 5   
   
 �� Key$ N��6    �� 	Modifiers$ Controlf�6    �� Command 61   �� *CreateMenuItemCommand+�� 5   
   $ Delete��6    6"   �� *DeleteDailyWorkItemCommand+ � 	Resources 5      *  $TM.DailyTrackR.DataType.EnumConverts   EnumConverts  StyledLabel	 �� 
TargetType
 �� Property �� Value �� 
TargetType  StyledButton �� Triggers P� Property P� Value �� CornerRadius �� Triggers  StyledCalendar&   System.Windows.Controls.Calendar  StyledTabitem  StyledDataGrid&   System.Windows.Controls.DataGrid)  #System.Windows.Controls.DataGridRow  
StyledGrid  DataGridColumnHeaderStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%:  &	        &	      &	 r    &	 s    &	 �    &	 <    &	 J	    &	 �	      5   
   6"   �� 5   
   "	 ��6$   .�5      �� 
 � ��$ 20(�6)   �� 5      
 � ��$ Tahoma)�6+   �� 5      
 � ��$ 10q�6'   �� 5      
 � ��
 ��� �6+   �� 5      
 � ��$
 Bold"�6+   �� 5      
 � �� 5      �� 5       " ��6&   .R�5!      �� #��z��6$   $��	Underline{�6E   5"      5$      5%      �� 5&   
   "	 ��6%   .�5'      �� 
 � ��$ Right=�64   �� 5(      
 � ��$ Center=�62   �� 5)      
 � ��$ 10q�6'   �� 5*      
 � ��$ 25��6&   �� 5+      
 � ��$ 25��6'   �� 5,      
 � ��$ 0q�60    5-      P� 5.       �@J�IsMouseOver$
 True��61   . �5/      �� 
 � ��$ 30��6.   �� 50      
 � ��$ 30��6/   �� 51      
 � �� 52      �� 53      " ��6.   .R�54   "   �� #��z��6)   #��z��55      #��z��56      $ 5��57      ._�58   &   �� $��Center=�67   $��Center=�6T   59   #    5:   "   P� 5;   &    �@J�IsMouseOver$
 True��6E   . �5<   *   �� 
 � ��$ 30��6B   �� 5=   *   
 � ��$ 30��6C   5>   '   5@      5B      5C      5E      �� 5F   
   "	  6'   .�5G      �� 
 � ��$ Center=�62   �� 5H      
 � ��$ Center=�64   �� 5I      
 � ��$
 Auto��6&   �� 5J      
 � ��$
 Auto��6'   �� 5K      
 � ��
 �����6+   �� 5L      
 � ��
 ��ح�6,   �� 5M      
 � ��$ 2q�60   �� 5N      
 � ��$ Tahoma)�6+   �� 5O      
 � ��$
 Bold"�6+   5P      �� 5Q   
   "	 ��6&   .�5R      �� 
 � ��$ Tahoma)�6+   5S      �� 5T   
   "	  6'   .�5U      �� 
 � ��
 �����6+   �� 5V      
 �@ AutoGenerateColumns$ False��64   �� 5W      
 � ��$ 10q�6'   �� 5X      
 � ��$ Stretch=�64   �� 5Y      
 � ��$ Stretch=�69   �� 5Z      
 �@ RowStyle 5[      �� 5\      "	  6   .�5]      �� 
 � ��
 �����67   �� 5^      
 � ��
 �   �67   �� 5_      
 � ��$ Tahoma)�67   �� 5`      
 � ��$ 12(�65   �� 5a      
 � ��$ Center=�6@    5b      P� 5c       �@ 
IsSelected$
 True��6<   . �5d   "   �� 
 � ��
 ��ح�6?   �� 5e   "   
 � ��
 �   �6?   5f      P� 5g       �@J�IsMouseOver$
 True��6=   . �5h   "   �� 
 � ��
 �����6?   5i      5k      5m      5n      �� 5o   
   "	 �6#   .�5p      �� 
 � ��
 ����6+   5q      �� 5r   
   "	  62   .�5s      �� 
 � ��
 �����6+   �� 5t      
 � ��
 �����6+   �� 5u      
 � ��$
 Bold"�6+   �� 5v      
 � ��$ Tahoma)�6+   �� 5w      
 � ��$ 14(�6)   �� 5x      
 � ��$ 5q�6(   �� 5y      
 � ��$ Center=�62   �� 5z      
 � ��$ Stretch=�64   5{      5|      .��5~      �  � ColumnDefinitions 5   
   �� 5�      $	��200 �6   �� 5�      $��* �6   .+�5�   
   �� $��0��6   $��Center=�6%   $��Center=�6B   .+�5�        -   5          Name$ Calendar��5�      #��[ 6^   5�      �� 5�   
   $��1��6   .@�5�      �� $��	DailyWork��6   #��[ 6)   .��5�      � #��[ 6    � RowDefinitions 5�      �� 5�      $��50 �6(   �� 5�      $��* �6(   .+�5�      �� -   5         ��Name$ 
DateLabel1��5�      $��Selected Date: ��60   $��0��6J   $��0��6W   #��[ 6g   �� 5�      -   5        $��0��5�   :   $��1��6G   #��[ 6W   ��5�      �� 5�       �� ImageSource$1 +/TM.DailyTrackR.View;component/plusicon.png��6)   5�        5�      -   5          Name$ DailyWorkDataGrid��5�      $��1��6:   #��[ 6�      ColumnHeaderStyle# [ 6�    � ContextMenu 5�      �� 5�      .@�5�   "   m� -   5        $��Create��5�   +   6;   m� 5�   "   -   5        $��Delete��5�   +   6;   5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��61      
IsReadOnly$
 True��6U      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6g   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6>   �� *NO+6g     5�      $ Project type��61   $
 True��6g   $ * 6y    6G   �� *ProjectType+6y     5�      $ 	Task type��61   $
 True��6�   $ * 6�    6D   �� *
TaskType+ �� 	Converter# [  6�     5�      $ Description��61   $ * 6f    6F   �� *Description+6f     5�      $ Status��61   $
 True��6�   $ * 6�    6A   �� *Status+# [  6�     5�      $ Id��61       
Visibility$  Hidden=�6T   $
 True��6h   $ * 6z    6=   �� *id+6z   5�      5�      5�      �� 5�      -   5        ! ��Name$! OverviewTab��5�      $��Overview��6+   #��[ 6=   .��5�      � #��[ 6    5�      �� 5�      $��5* �6+   �� 5�      $	��94* �6+    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   �� 5�      $
��Auto �6(   .+�5�      �� -	   5        $ 
DateLabel2��5�      $��Selected Date: ��60   $��0��6J   $��2��6W   #��[ 6k     5�      -
   5        $ OverviewDataGrid��5�      "   
IsReadOnly$
" True��69   $��1��6K   #��[ 6X   $��2��6�   # [ 6�    5�        5�      $	 No.��61   $
 True��6U   $ * 6g    6>   �� *NO+6g     5�      $ Project type��61   $
 True��6g   $ * 6y    6G   �� *ProjectType+6y     5�      $ Description��61   $
 True��6f   $ * 6x    6F   �� *Description+6x     5�      $ Status��61   $
 True��6�   $ * 6�    6A   �� *Status+# [  6�     5�      $
 User��61   $
 True��6X   $ * 6j    6?   �� *User+6j   5�      � 5�      $��2��6   $��10,10,10,10q�6(   $��2��6=    5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   .+�5�      �� $��Select Date Range: ��6    $��0��6>   #��[ 6N   $��Center=�6s     5�      -   5        $ DateRangeCalendar��5�   #   #   SelectionMode$# SingleRange=�6>   $   DisplayMode$$ Month=�6Z   $��5q�6n   $��1��6y   �� 5�      -   5        $��2��5�   <   #��[ 6L   $��Bottom=�6r   ��5�      �� 5�   "   $1 +/TM.DailyTrackR.View;component/download.png��6-   5�      5�      �� 5�      -   5        % ��Name$% LoadingIndicator��5�      $-��'/TM.DailyTrackR.View;component/load.png��66   $
��Left=�6g   $��Center=�6�   $y�	Collapsed=�6�   $	��200��6�   $	��200��6�   $��1��6�   $��	167,0,0,0q�6�   5�      5�      5�      5�      5�      