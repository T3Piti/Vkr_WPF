   M S B A M L   `   `   `  ����B  >Vkr_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Vkr_WPF.Views.PagesVkr_WPF.Views.Pages  5      (    "Vkr_WPF.Views.Pages.AddProjectPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Vkr_WPF.Views.Pages     5        N� Title$  AddProjectPage��5	       N� 
FontFamily$0 */Vkr_WPF;component/Fonts/#Natural Mono Alt)�5
       � 	Resources 5         
LabelStyle �� 
TargetType �� Property �� Value  TextBoxStyle��%�  &	        &	 �     �� 5   
   " ��6#   .�5      ��  � ��$ 26(�6)   �� 5       � ��$ Center=�64   �� 5       � �� �#0D0D2E6+   �� 5       � ��$ 5q�6'   5      �� 5   
   .�5      ��  � ��
 ���� 68   �� 5       � ��$ Center=�6F   �� 5       � ��$ 0q�6=   �� 5       � ��$ 5q�65   �� 5       � �� �#DBDBEA68   �� 5       � ��$ 20(�66   �� 5       � ��$	 280��63   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5!   
   �� $��0��6    �� Orientation$ Vertical=�6%   .+�5$      �� $%��Название проекта��6   #��[  5%      
������ ���#0D0D2E$��Center=�5(      �� 5)       �� CornerRadius$ 10��6   ���#0D0D2E$	��300��5+      $��50��5,      $��5q�5-      ._�5.      � .+�5/      �� $��1��6    �� 50      -   5        	 ��Name$	 ProjectNameBox��51      #��[ 50      ��52      �� *ProjectName+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 53       J� IsHitTestVisible .  $%��Название проекта��54       $��Center=�55       $
��Left=�56       
�������$��13(�58        �� Padding$ 5q�59       $��10,0,0,0q�5:       ��5;      �� 5<      " ��6$    �� Triggers 5=   "   �� 5>   &    �� Binding 62   �� *Text+ �� ElementName$ ProjectNameBox�� �� Value  6g   .a�5?   *   ��  � y�$ Visible=�6G   5@   '   .�5B   "   ��  � y�$ Hidden=�6?   5C      5E      5F      5G      �� 5J      $��Дата начала��6   #��[  5K      
������ ���#0D0D2E$��Center=�5N      (  "System.Windows.Controls.DatePicker  5O      $	��300��6      SelectedDate 5P      �� *	DateStart+$
 TwoWay=�$ PropertyChanged=��� 5S      $!��Дата окончания��6   #��[  5T      
������ ���#0D0D2E$��Center=�5W        5X      $	��300��6    5Y      �� *	DateEnd+$
 TwoWay=�$ PropertyChanged=��� 5\      $ 15��6   ���#0D0D2E$	��300��5^      $��50��5_      $��10q�5`      ._�5a      � .+�5b      �� $��1��6    �� 5c      $	��300��6   
������ $��0q�5d      $#��Добавить проект��5e      ���#DBDBEA$��20(�5g      ��5h      �� *AddProjectCommand+5i      5j      5k      5l      5m      