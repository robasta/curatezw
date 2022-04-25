select p.Id as id, p.Title as title, p.Body as body, p.Slug as slug, p.CharacterCount as characterCount, p.CreatedDate as createdDate, tags.Title as title, tags.slug as slug, tags.Description as [description] from dbo.[Post] as p
left join dbo.[TagPost] as tp on tp.Post_Id = p.Id
left join dbo.[Tag] as tags on  tags.Id = tp.Tag_Id
for JSON AUTO,  INCLUDE_NULL_VALUES
