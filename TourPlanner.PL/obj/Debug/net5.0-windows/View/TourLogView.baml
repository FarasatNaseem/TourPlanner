   M S B A M L   `   `   `  ����I  ETourPlanner.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TourPlanner.PLTourPlanner.PL  5      9!clr-namespace:TourPlanner.PL.ViewTourPlanner.PL.View  5      P LTourPlanner.Client.BL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullpLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BLTourPlanner.Client.BL.ViewModel 5	      %    TourPlanner.PL.View.TourLogView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hc19http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      .localclr-namespace:TourPlanner.PL     5      2view!clr-namespace:TourPlanner.PL.View     5      b	viewmodelLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BL     5	      .��5      ]� .+�5   
   �� $
��Left=�5      $
��Fill=�5      $��8��5      $	��300��6   ��5      �� *Tours[0].RouteImage+5      �� 5   
   $��20(�6   $	��Top=�6   ��63   �� *Tours[0].Name+6W   $   TourPlanner.PL.View.SearchView  5   
   $	��Top=�6   $��Center=�6/   $��10(�6J     � DataContext  6X   �� *
SearchVM+�� 5   
   $	��Top=�6    �� CornerRadius$ 1��6&   
�������
�������$��0q�6b   ._�5      ]� .+�5      � $	��Top=�6    � ColumnDefinitions 5       �� 5!      $��3* �6+   �� 5"      $��1* �6+   �� 5#      $��1* �6+   �� 5$      $��1* �6+    � RowDefinitions 5'      �� 5(      $��40 �6(   �� 5)      $��1* �6(   .+�5,      �� 
�������
�������$��1q�6H   $��3��6\   $��2q�6p   ._�5-      �� $��15(�6    .��5.      �� .�6#   Log6(   5/      50      �� 51      
�������
�������$��1q�6H   $��3��6\   $��4��6p   $��2q�6�   ._�52      �� $��Add Log��6�   ��6!   �� *DataContext.UpdateViewCommand+ �� RelativeSource �� *FindAncestor+ �� AncestorType" >���6�   �� 6�   53      54      55      56      �� 58   
   
�������
�������$��1q�6<   ._�59      � $��2q�6   $	��Top=�6   $��4��63   .+�5:      �� 
�������
�������$��1q�6E   $��2q�6Y   ._�5;      &   System.Windows.Controls.DataGrid     RowDetailsVisibilityMode$ Visible=�6=      AutoGenerateColumns$ False��6`   ��6   �� *Tours+   Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��61   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Name+6Y     5>      $
	 From��61   $

 Auto 6Y    6?   �� *From+6Y     5?      $	 To��61   $

 Auto 6U    6=   �� *To+6U     5@      $	 Distance��61   $

 Auto 6a    6C   �� *
Distance+6a     5A      $	 Description��61   $

 Auto 6g    6F   �� *Description+6g     5B      $	 Transport type��61   $

 Auto 6l    6I   �� *TransportType+6l     5C      $	 Estimated time��61   $

 Auto 6l    6I   �� *EstimatedTime+6l   4  .System.Windows.Controls.DataGridTemplateColumn  5D         CellTemplate 5E   "   �� 5F   &   .R�5G   *   � .+�5H   .   �� 
�������
�������$��1q�6a   $��3��6u   $��2q�6�   ._�5I   2   �� $��Generate Report��6�   ��69   �� *)'DataContext.GenerateNormalReportCommand+ �� *FindAncestor+" >���6�   �� 6�   5J   /   5K   +   5L   '   5N         RowDetailsTemplate 5P      �� 5Q      .R�5R   "     $ False��6H   ��6+   �� *Logs+ 5S   &     5T   *   $	 DateTime��6=   $

 Auto 6l    6O   �� *
DateTime+6l     5U   *   $	 Comment��6=   $

 Auto 6j    6N   �� *	Comment+6j     5V   *   $	 
Difficulty��6=   $

 Auto 6p    6Q   �� *
Difficulty+6p     5W   *   $	 Duration��6=   $

 Auto 6q    6O   �� *TotalDuration+6q     5X   *    5Y   .   �� 5Z   2   .R�5[   6   � .+�5\   :   �� 
�������
�������$��1q�6m   $��3��6�   $��2q�6�   ._�5]   >   �� $��Remove��6�   ��6E   �� *DataContext.DeleteCommand+ �� *FindAncestor+" >���6�   ��  �� Path$ Id�6�   5^   ;   5_   7   5`   3   5b   +     5c   *    5d   .   �� 5e   2   .R�5f   6   � .+�5g   :   �� 
�������
�������$��1q�6m   $��2q�6�   ._�5h   >   �� $��Update��6�   ��6E   �� *DataContext.UpdateViewCommand+ �� *FindAncestor+" >���6�   �� 5i   ?   5j   ;   5k   7   5l   3   5n   +   5p   #   5q      5s      5t      5u      5v      5x      5y      