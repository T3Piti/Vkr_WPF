   M S B A M L   `   `   `  ����B  >Vkr_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Vkr_WPF.Views.PagesVkr_WPF.Views.Pages  5      *    $Vkr_WPF.Views.Pages.ProjectsListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Vkr_WPF.Views.Pages     5        N� 
FontFamily$0  */Vkr_WPF;component/Fonts/#Natural Mono Alt)�5	       � 	Resources 5
         TextBoxStyle �� Property �� Value��%+  &	        �� 5   
   .�5      ��  � ��
 ���� 68   �� 5       � ��$ Center=�6F   �� 5       � ��$ 0q�6=   �� 5       � ��$ 5q�65   �� 5       � �� �#DBDBEA68   �� 5       � ��$ 20(�66   �� 5       � ��$	 280��63   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Проекты��6   $��5q�5      $��10q�5      $��20(�5      $��Center=�5       $��Stretch=�5!      
������ ���#0D0D2E5#      �� 5$       �� CornerRadius$ 15��6   ���#0D0D2E$	��300��5&      $��50��5'      $��10q�5(      ._�5)      � .+�5*      �� $��1��6    �� 5+      -   5         ��Name$ SearchProjectBox��5,      #��[  5+      ��5-      �� *SearhString+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=��� 5.      
 J� IsHitTestVisible
 .  $��Поиск проекта��5/       $��Center=�50       $
��Left=�51       
�������$��13(�53        �� Padding$ 5q�54       $��10,0,0,0q�55       ��56      �� 57       �� 
TargetType" ��6$    �� Triggers 58   "   �� 59   &    �� Binding 62   �� *Text+ �� ElementName$ SearchProjectBox�� �� Value  6i   .a�5:   *   ��  � y�$ Visible=�6G   5;   '   .�5=   "   ��  � y�$ Hidden=�6?   5>      5@      5A      5B      5C      �� 5E   
   $��1��6   
������ $	��200��5G      $��2q�5H      $��5q�5I      $	��Top=�5J      ��5E   8   �� *ProjectList+ �� SelectedItem 5F      �� *SelectedProject+$	 TwoWay=�$ PropertyChanged=���5K      �� 5L      .R�5M      �  � Orientation$ 
Horizontal=�6     K� IsItemsHost . 69   5N      ��5P      �� 5Q      .R�5R      �� $ 30��6   ���#1A0C2C$	��300��5T      $	��150��5U      $��10q�5V      ._�5W      � .+�5X      �� $��1��6(   �� 5Y      .+�5Z   "   �� $��5q�5[   $   $��10,5,5,0q�5\   $   $��20(�5]   $   $��Center=�5^   $   $��Stretch=�5_   $   
������ ���#DBDBEA��5Z   (   ��  �� Path$
 name�5a   $   �� 5b   "   $��5q�5c   $   $��10,5,5,0q�5d   $   $��20(�5e   $   $��Center=�5f   $   $��Stretch=�5g   $   
������ ���#DBDBEA��5b   (   �� $ 
date_start�5i   $   �� 5j   "   $��5q�5k   $   $��10,5,5,0q�5l   $   $��20(�5m   $   $��Center=�5n   $   $��Stretch=�5o   $   
������ ���#DBDBEA��5j   (   �� $ date_end�5q   $   5r      5s      5t      5u       � ContextMenu 5w      �� 5x      .@�5y      m� $��Просмотреть��6    m� Command 5z      �� *ShowProjectPageCommand+m� 5{      $#��Добавить проект��6    5|      �� *AddProjectCommand+m� 5}      $!��Удалить проект��6    5~      �� *DeleteProjectCommand+5      5�      5�      5�      