class Categorie {
  final int idCategorie;
  final String? libelleCategorie;


  Categorie({
    required this.idCategorie,
    required this.libelleCategorie,
    
  });

  factory Categorie.fromJson(Map<String, dynamic> json) {
    return Categorie(
      idCategorie: json['idCategorie'],
      libelleCategorie: json['libelleCategorie'],   
    );
  }
}