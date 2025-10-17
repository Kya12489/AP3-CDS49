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
    return Column(
      children: [
        Container(
          width: 230,
          height: 230,
          child: InkWell(
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
                      // centrer le contenu (icône + titre)
                      mainAxisAlignment: MainAxisAlignment.center,
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        Icon(
                          this.icon,
                          size: 40,                        
                        ),
                        SizedBox(height: 12),
                        Text(
                          'Questions '+this.title,
                          textAlign: TextAlign.center,
                          style: TextStyle(
                            fontSize: 15,
                            fontWeight: FontWeight.bold,                            
                          ),
                        ),                        
                      ],
                    ),
                  ),                  
                ),                
              ),
        ),
        
      ],
    );
  }
}