   M S B A M L   `   `   `  ����I  ETourPlanner.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TourPlanner.PL.ViewTourPlanner.PL.View  5      P LTourPlanner.Client.BL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullpLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BLTourPlanner.Client.BL.ViewModel 5      %    TourPlanner.PL.View.ReviewsView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TourPlanner.PL.View     5      b	viewmodelLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BL     5      .��5      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   
�������
�������$��1q�6I   ._�5      � $��2q�6   $	��Top=�6   $��4��63   .+�5      �� 
�������
�������$��1q�6E   $��2q�6Y   ._�5      &   System.Windows.Controls.DataGrid     RowDetailsVisibilityMode$ Visible=�6?      AutoGenerateColumns$ False��6b   ��6   �� *	Reviews+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Name+6Y     5      $ Feedback��61   $
 Auto 6a    6C   �� *
Feedback+6a   5      5      5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5       �� $��10q�6   $	��200��6!   $��Go Home��6-   $��Go Home��6e   ��6?   �� *UpdateViewCommand+6e   5!      5"      5#      