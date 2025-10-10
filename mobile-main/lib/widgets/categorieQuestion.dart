import 'package:flutter/material.dart';

class CategorieQuestion extends StatelessWidget {
  final String title;
  final IconData icon;
  final VoidCallback onTap;
  final String nameSelected;

  const CategorieQuestion({
    Key? key,
    required this.title,
    required this.icon,
    required this.onTap,
    required this.nameSelected,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return InkWell(
                onTap: this.onTap,
                borderRadius: BorderRadius.circular(12),
                child: AnimatedContainer(
                  duration: Duration(milliseconds: 200),
                  curve: Curves.easeInOut,
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(12),
                    boxShadow: [
                      BoxShadow(
                        blurRadius: this.nameSelected == this.title ? 8 : 2,
                        offset: Offset(0, this.nameSelected == this.title ? 4 : 1),
                      ),
                    ],
                    color: Theme.of(context).cardColor,
                  ),
                  child: Padding(
                    padding: EdgeInsets.symmetric(vertical: 32, horizontal: 40),
                    child: Column(
                      children: [
                        Icon(
                          this.icon,
                          size: 40,                        
                        ),
                        Text(
                          'Questions '+this.title,
                          style: TextStyle(
                            fontSize: 18,
                            fontWeight: FontWeight.bold,                            
                          ),
                        ),
                        SizedBox(height: 16),
                        
                      ],
                    ),
                  ),
                ),
              );
  }
}