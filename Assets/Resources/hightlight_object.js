#pragma strict

function OnMouseOver()
{
GetComponent.<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
}

function OnMouseExit()
{
GetComponent.<Renderer>().material.shader = Shader.Find("Diffuse");
}
