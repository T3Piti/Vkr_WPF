   M S B A M L   `   `   `  ����B  >Vkr_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Vkr_WPF.Views.WindowsVkr_WPF.Views.Windows  5   	   &     Vkr_WPF.Views.Windows.TaskWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Vkr_WPF.Views.Windows     5   	     � Title$  
TaskWindow��5   	   $	��490��6   $	��800��6)   ���#DBDBEA � WindowStartupLocation$ CenterScreen=�5
   	   $0��*/Vkr_WPF;component/Fonts/#Natural Mono Alt)�5   	    � 	Resources 5         
LabelStyle �� 
TargetType �� Property �� Value  TextBoxStyle��%�  &	        &	 �     �� 5   
   " ��6#   .�5      ��  � ��$ 30(�6)   �� 5       � ��$ Center=�64   �� 5       � �� �#0D0D2E6+   �� 5       � ��$ 5q�6'   5      �� 5   
   .�5      ��  � ��
 ���� 68   �� 5       � ��$ Center=�6F   �� 5       � ��$ 0q�6=   �� 5       � ��$ 5q�65   �� 5       � �� �#DBDBEA68   �� 5       � ��$ 20(�66   �� 5       � ��$	 280��63   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��75 �6   �� 5       .+�5"   
   �� #���   6_   $
��Left=�6�   ��6   �� *
TaskName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   � 5#   
   $��1��6   	 � ColumnDefinitions	 5$      �� 5%      $	��400 �6#   �� 5&      $	��400 �6#    5(      �� 5)      $��55 �6    �� 5*      .+�5.      �� $��Описание��6   #���   6'   $��Center=�6L   $��26(�5/      �� 51      $��1��6   
 �� Orientation$
 
Horizontal=�6)   .+�52      �� $��Сотрудники��6   #���   6-   $��26(�53      �� 54       �� CornerRadius$ 10��6   ���#0D0D2E$	��200��56      $��40��57      $��5q�58      ._�59      � .+�5:      �� $��1��6$   �� 5;      -   5         ��Name$ EmployeeSearchTextBox��5<   "   #��[ 5;   "   ��5=   "   �� *SearchEmployee+$ PropertyChanged=�$ TwoWay=��� 5>       J� IsHitTestVisible .  $%��Поиск сотрудника��5?   $   $��Center=�5@   $   $
��Left=�5A   $   
�������$��13(�5C   $    �� Padding$ 5q�5D   $   $��10,0,0,0q�5E   $   ��5F      �� 5G   "   " ��6(    �� Triggers 5H   &   �� 5I   *    �� Binding 66   �� *Text+ �� ElementName$ EmployeeSearchTextBox�� �� Value  6r   .a�5J   .   ��  � y�$ Visible=�6K   5K   +   .�5M   &   ��  � y�$ Hidden=�6C   5N   #   5P      5Q      5R      5S      �� 5V      $ 10��6   $��1��5W      ���#0D0D2E$	��380��5Y      $	��300��5Z      $��10q�5[      ._�5\      � .+�5]      �� $��1��6    �� 5^      
������ $��0q�5`      ���#DBDBEA �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5c      $ �� HorizontalScrollBarVisibility$
 Auto=�5d      $��20(�5e      $��10q�5f      ��5^      �� *TaskDescription+$ TwoWay=�$ PropertyChanged=� �� 
IsReadOnly 5g      �� *DescriptionIsReadOnly+$ TwoWay=�$ PropertyChanged=�.��6}    � ContextMenu 5h      �� 5i      .@�5j   "   m� $��Сохранить��6+   y�5k   +   �� *SaveDescriptionVisibility+$ TwoWay=�$ PropertyChanged=� m� Command 5l   +   �� *SaveDescriptionCommand+m� 5m   "   $ ��Редактировать��6+   y�5n   +   �� *EditDescriptionVisibility+$ TwoWay=�$ PropertyChanged=� 5o   +   �� *EditDescriptionCommand+5p      .��5q   /   5r      5s      5t      �� 5w      $��1��6   $��1��6&   
������ $	��200��5{      $��2q�5|      $��10q�5}      $	��Top=�5~      ��5y      �� *EmployeesList+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 5z      �� *SelectedEmployee+��5      �� 5�      .R�5�      �  � Orientation$ Vertical=�6$    K� IsItemsHost . 6;   5�      ��5�      �� 5�      .R�5�      �� $ 20��6!   ���#1A0C2C$	��300��5�   !   $	��150��5�   !   $��10q�5�   !   ._�5�      � .+�5�   "   �� $��1��6,   �� 5�   "   .+�5�   &   �� $��5q�5�   ,   $��10,5,5,0q�5�   ,   $��15(�5�   ,   $��Center=�5�   ,   $��Stretch=�5�   ,   
������ ���#DBDBEA��5�   ,   ��  �� Path$
 Name�5�   ,   �� 5�   &   $��5q�5�   ,   $��10,5,5,0q�5�   ,   $��15(�5�   ,   $��Center=�5�   ,   $��Stretch=�5�   ,   
������ ���#DBDBEA��5�   ,   �� $ 
SecondName�5�   ,   �� 5�   &   $��5q�5�   ,   $��10,5,5,0q�5�   ,   $��15(�5�   ,   $��Center=�5�   ,   $��Stretch=�5�   ,   
������ ���#DBDBEA��5�   ,   �� $ 
Patronymic�5�   ,   �� 5�   &   $��5q�5�   ,   $��10,5,5,0q�5�   ,   $��15(�5�   ,   $��Center=�5�   ,   $��Stretch=�5�   ,   
������ ���#DBDBEA��5�   ,   �� $ 
Department�5�   ,   5�   #   5�      5�      5�       5�      �� 5�      .@�5�      m� $��Просмотреть��6#    5�   #   �� *ShowEmployeeWindowCommand+m� 5�      $��Добавить��6#    5�   #   �� *ShowAddEmployeeWindowCommand+m� 5�      $��Удалить��6#    5�   #   �� *DeleteEmployeeCommand+5�      5�      5�      5�      5�      