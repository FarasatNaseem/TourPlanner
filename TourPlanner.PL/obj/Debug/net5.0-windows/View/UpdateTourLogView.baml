   M S B A M L   `   `   `  ����I  ETourPlanner.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TourPlanner.PL.ViewTourPlanner.PL.View  5      P LTourPlanner.Client.BL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullpLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BLTourPlanner.Client.BL.ViewModel 5      +    %TourPlanner.PL.View.UpdateTourLogView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:TourPlanner.PL.View     5      b	viewmodelLclr-namespace:TourPlanner.Client.BL.ViewModel;assembly=TourPlanner.Client.BL     5      $��15(�5        � 	Resources  5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��10q�6    �� Padding$ 10q�6   $��0��6*   $��Center=�5   	   $��Center=�5   	   
�������$��3q�5   	    �� CornerRadius$ 10��5   	    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      Color$
 Gray��63   ._�5       �  � IsSharedSizeScope$
 True��6    5!      �� 5"      $
��auto �6$   �� 5#      $
��auto �6$   .+�5&      �� $��0��6   $��Center=�5'      $��48(�5(      $��Tour Planner��5)      � 5+      $��1��6   $
��0,20q�6$    5,      �� 5-      $
��auto �6(   �� 5.      $
��auto �6(   �� 5/      $
��auto �6(   �� 50      $
��auto �6(   �� 51      $
��auto �6(   �� 52      $
��auto �6(   �� 53      $
��auto �6(   .+�56      � $��0��6   $
��0,10q�6(    � ColumnDefinitions 57      �� 58      $
��auto �6/   	 z� SharedSizeGroup$	 Label��6<   �� 59      $	��300 �6/   .+�5<      �� $��0��6$   $��
Difficulty��64   �� 5=      $��1��6"   $��20,0,0,0q�62   ��5>      �� *
Difficulty+
 �� UpdateSourceTrigger$
 PropertyChanged=�5?      � 5A      $��1��6   $
��0,10q�6(    5B      �� 5C      $
��auto �6/   $	 Label��6<   �� 5D      $	��300 �6/   .+�5G      �� $��0��6$   $��Datatime��64   �� 5H      $��1��6"   $��20,0,0,0q�62   ��5I      �� *
DateTime+$
 PropertyChanged=�5J      � 5L      $��2��6   $
��0,10q�6(    5M      �� 5N      $
��auto �6/   $	 Label��6<   �� 5O      $	��300 �6/   .+�5R      �� $��0��6$   $��Comment��64   �� 5S      $��1��6"   $��20,0,0,0q�62   ��5T      �� *	Comment+$
 PropertyChanged=�5U      � 5W      $��3��6   $
��0,10q�6(    5X      �� 5Y      $
��auto �6/   $	 Label��6<   �� 5Z      $	��300 �6/   .+�5]      �� $��0��6$   $��Rating��64   �� 5^      $��1��6"   $��20,0,0,0q�62   ��5_      �� *Rating+$
 PropertyChanged=�5`      � 5b      $��4��6   $
��0,10q�6(    5c      �� 5d      $
��auto �6/   $	 Label��6<   �� 5e      $	��300 �6/   .+�5h      �� $��0��6$   $��Duration��64   �� 5i      $��1��6"   $��20,0,0,0q�62   ��5j      �� *TotalDuration+$
 PropertyChanged=�5k      �� 5n      $��5��6   $
��0,10q�6*   $	��100��68   $��Center=�5o      $��Update��5r       �� 	IsDefault$
 True��5s      ��5p      �� *DataContext.UpdateCommand+ �� RelativeSource �� *FindAncestor+ �� AncestorType" >���5q      �� 5s      �� 5u      $��6��6    $��0,10,0,0q�6-   $��Center=�5v      
���  �� � DataContext 5w      �� *MessageViewModel+��5y      �� *	Message+y�5z      �� *
HasMessage+ �� 	Converter# [  5{      5|      5}      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5�      �� $��10q�6   $	��200��6!   $��Go Home��6-   $��Go Home��6e   ��6?   �� *UpdateViewCommand+6e   5�      5�      5�      